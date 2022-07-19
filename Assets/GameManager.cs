using System;
using UnityEngine;
// Photon 用の名前空間を参照する
using Photon.Pun;
using Photon.Pun.UtilityScripts;    // PunTurnManager, IPunTurnManagerCallbacks を使うため
using Photon.Realtime;

/// <summary>
/// ゲーム・ターンを管理するコンポーネント
/// </summary>
public class GameManager : MonoBehaviour, IPunTurnManagerCallbacks
{
    /// <summary>プレイヤーの出現ポイント</summary>
    [SerializeField] Transform[] _spawnPositions;
    /// <summary>プレイヤーのプレハブ名</summary>
    [SerializeField] string _playerPrefabName = "Player";
    /// <summary>矢印のオブジェクト</summary>
    [SerializeField] ArrowController _arrow;
    Vector3 _arrowDirection;
    /// <summary>パワーゲージ</summary>
    [SerializeField] PowerGaugeController _gauge;
    /// <summary>プレイヤーの Rigidbody</summary>
    [SerializeField] Rigidbody _player;
    /// <summary>弾くパワーの倍率</summary>
    [SerializeField] float _powerScale = 1f;
    [SerializeField] PunTurnManager _turnManager;
    /// <summary>現在のフェーズ</summary>
    Phase _phase = Phase.none;
    /// <summary>直前のフレームでのフェーズ</summary>
    Phase _lastPhase = Phase.none;
    /// <summary>自分が何番目のプレイヤーか（0スタート。途中抜けを考慮していない）</summary>
    int _playerIndex = -1;
    /// <summary>現在何番目のプレイヤーが操作をしているか（0スタート。途中抜けを考慮していない）</summary>
    int _activePlayerIndex = -1;

    /// <summary>
    /// ゲームを初期化する
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
        // 自分の番ではない時は何もしない
        if (_activePlayerIndex != _playerIndex) return;

        // 方向を決めるフェーズに入った時
        if (_phase == Phase.Direction && _lastPhase != Phase.Direction)
        {
            _arrow.gameObject.SetActive(true);
        }
        else if (_phase == Phase.Direction && Input.GetButtonDown("Fire1")) // 方向を決めるフェーズでクリックされた時
        {
            _arrowDirection = _arrow.gameObject.transform.forward;
            _arrow.Stop();  // Arrowの回転を止める
            _gauge.gameObject.SetActive(true);
            _gauge.StartGauge();
            _phase = Phase.Power;
        }
        else if (_phase == Phase.Power && Input.GetButtonDown("Fire1")) // パワーを決めるフェーズに入った時
        {
            _arrow.gameObject.SetActive(false);
            float power = _gauge.StopGauge();
            _player.AddForce(_arrowDirection * power * _powerScale, ForceMode.Impulse);
            _turnManager.SendMove(null, true);
        }

        _lastPhase = _phase;
    }

    #region IPunTurnManagerCallbacks の実装
    void IPunTurnManagerCallbacks.OnTurnBegins(int turn)
    {
        Debug.Log($"Enter OnTurnBegins. turn: {turn}");

        if (turn == 1)
        {
            InitializeGame();
        }

        _activePlayerIndex = 0;    // 最初のプレイヤーからターンを始める
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
/// ゲームのフェーズ
/// TODO: 別の「定数を宣言するクラス」に移動すべき
/// </summary>
public enum Phase
{
    /// <summary>自分の番ではないなど未定義の状態</summary>
    none,
    /// <summary>方向を決めるフェーズ</summary>
    Direction,
    /// <summary>パワーを決めるフェーズ</summary>
    Power,
}