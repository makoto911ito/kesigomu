using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

/// <summary>
/// ������������ĉ�ʂɏ����҂��o�����߂̃X�N���v�g
/// </summary>
public class VictoryJudg : MonoBehaviour
{
    List<int> _playersList = new List<int>();

    PhotonView _photonView;
    [SerializeField] Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        //�f�o�b�N�p
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("�v���C���[�̍ő吔��" + _playersList.Count + "�l");

            foreach (var i in _playersList)
            {
                Debug.Log("���ݎc���Ă���v���C���[�̔ԍ���" + i + "��");
            }
        }
    }

    /// <summary>���X�g�̓������s���֐�</summary>
    /// <param name="playernum">�v���C���[�̔ԍ�</param>
    public void SyncLIst(int playernum)
    {
        object[] _parameter = new object[] { playernum };
        _photonView.RPC("RemoveList", RpcTarget.All, _parameter);
    }

    /// <summary>
    /// �����Ɏ󂯎�����v���C���[�̔ԍ��Ɠ����ԍ���_playersList�����������֐�
    /// </summary>
    /// <param name="playernum">�v���C���[�̔ԍ�</param>
    [PunRPC]
    void RemoveList(int playernum)
    {
        _playersList.Remove(playernum);
    }

    /// <summary>
    /// _playersList�����������邽�߂̊֐�
    /// </summary>
    public void CreateList(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _playersList.Add(i);
        }
    }

    [PunRPC]
    public void Judg()
    {
        Debug.Log("���蒆");

        if (_playersList.Count == 1)
        {
            _text.text = _playersList[0] + "�̏���".ToString();
        }
        else if(_playersList.Count == 0)
        {
            _text.text = "��������".ToString();
        }
    }
}
