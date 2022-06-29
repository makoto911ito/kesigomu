using System;
using UnityEngine;
// Photon �p�̖��O��Ԃ��Q�Ƃ���
using Photon.Pun;
using Photon.Pun.UtilityScripts;    // PunTurnManager, IPunTurnManagerCallbacks ���g������
using Photon.Realtime;

/// <summary>
/// �Q�[���E�^�[�����Ǘ�����R���|�[�l���g
/// </summary>
public class GameManager : MonoBehaviour, IPunTurnManagerCallbacks
{
    /// <summary>�v���C���[�̏o���|�C���g</summary>
    [SerializeField] Transform[] _spawnPositions;
    /// <summary>�v���C���[�̃v���n�u��</summary>
    [SerializeField] string _playerPrefabName = "Player";
    /// <summary>���̃I�u�W�F�N�g</summary>
    [SerializeField] ArrowController _arrow;
    /// <summary>�p���[�Q�[�W</summary>
    [SerializeField] PowerGaugeController _gauge;
    /// <summary>�v���C���[�� Rigidbody</summary>
    [SerializeField] Rigidbody _player;
    /// <summary>�e���p���[�̔{��</summary>
    [SerializeField] float _powerScale = 1f;
    [SerializeField] PunTurnManager _turnManager;
    /// <summary>���݂̃t�F�[�Y</summary>
    Phase _phase = Phase.none;
    /// <summary>���O�̃t���[���ł̃t�F�[�Y</summary>
    Phase _lastPhase = Phase.none;
    /// <summary>���������Ԗڂ̃v���C���[���i0�X�^�[�g�B�r���������l�����Ă��Ȃ��j</summary>
    int _playerIndex = -1;
    /// <summary>���݉��Ԗڂ̃v���C���[����������Ă��邩�i0�X�^�[�g�B�r���������l�����Ă��Ȃ��j</summary>
    int _activePlayerIndex = -1;

    /// <summary>
    /// �Q�[��������������
    /// </summary>
    void InitializeGame()
    {
        Debug.Log("Initialize Game...");
        _playerIndex = Array.IndexOf(PhotonNetwork.PlayerList, PhotonNetwork.LocalPlayer);
        float angle = UnityEngine.Random.Range(-180f, 180f);
        var go = PhotonNetwork.Instantiate(_playerPrefabName, _spawnPositions[_playerIndex].position, Quaternion.Euler(0f, angle, 0f));
        _arrow.Player = go;
        _arrow.gameObject.SetActive(false);
        _player = go.GetComponent<Rigidbody>();
    }


    void Update()
    {
        // �����̔Ԃł͂Ȃ����͉������Ȃ�
        if (_activePlayerIndex != _playerIndex) return;

        // ���������߂�t�F�[�Y�ɓ�������
        if (_phase == Phase.Direction && _lastPhase != Phase.Direction)
        {
            _arrow.gameObject.SetActive(true);
        }
        else if (_phase == Phase.Direction && Input.GetButtonDown("Fire1")) // ���������߂�t�F�[�Y�ŃN���b�N���ꂽ��
        {
            _gauge.gameObject.SetActive(true);
            _gauge.StartGauge();
            _phase = Phase.Power;
        }
        else if (_phase == Phase.Power && Input.GetButtonDown("Fire1")) // �p���[�����߂�t�F�[�Y�ɓ�������
        {
            _arrow.gameObject.SetActive(false);
            float power = _gauge.StopGauge();
            _player.AddForce(_arrow.transform.forward * power * _powerScale, ForceMode.Impulse);
            _turnManager.SendMove(null, true);
        }

        _lastPhase = _phase;
    }

    #region IPunTurnManagerCallbacks �̎���
    void IPunTurnManagerCallbacks.OnTurnBegins(int turn)
    {
        Debug.Log($"Enter OnTurnBegins. turn: {turn}");

        if (turn == 1)
        {
            InitializeGame();
        }

        _activePlayerIndex = 0;    // �ŏ��̃v���C���[����^�[�����n�߂�
        _phase = Phase.Direction;
    }

    void IPunTurnManagerCallbacks.OnPlayerMove(Player player, int turn, object move)
    {
        Debug.Log($"Enter OnPlayerMove. player: {player.ActorNumber}, turn: {turn}, move: {move.ToString()}");
    }

    void IPunTurnManagerCallbacks.OnPlayerFinished(Player player, int turn, object move)
    {
        _activePlayerIndex = (_activePlayerIndex + 1) % PhotonNetwork.CurrentRoom.PlayerCount;
    }

    void IPunTurnManagerCallbacks.OnTurnCompleted(int turn)
    {
        Debug.Log($"Enter OnTurnCompleted. turn: {turn}");

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("I am MasterClient. I begin turn.");
            _turnManager.BeginTurn();
        }
    }

    void IPunTurnManagerCallbacks.OnTurnTimeEnds(int turn)
    {
        Debug.Log($"Enter OnTurnTimeEnds. turn: {turn}");
    }
    #endregion
}

/// <summary>
/// �Q�[���̃t�F�[�Y
/// TODO: �ʂ́u�萔��錾����N���X�v�Ɉړ����ׂ�
/// </summary>
public enum Phase
{
    /// <summary>�����̔Ԃł͂Ȃ��Ȃǖ���`�̏��</summary>
    none,
    /// <summary>���������߂�t�F�[�Y</summary>
    Direction,
    /// <summary>�p���[�����߂�t�F�[�Y</summary>
    Power,
}