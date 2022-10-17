using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// �������v���C���[�����S�Ɣ��f���邽�߂̃X�N���v�g
/// </summary>
public class DeadLine : MonoBehaviour
{
    [SerializeField] VictoryJudg _victoryJudg;
    [SerializeField] GameManager _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        //�����Ă����I�u�W�F�N�g�̔��ʂ��A�v���C���[�ł���΂��̃v���C���[�͎��S�Ƃ���
        if(other.gameObject.CompareTag("Player"))
        {
            PhotonView _photonView = other.gameObject.GetComponent<PhotonView>();

            Debug.Log("���񂾃v���C���[�̔ԍ���" + _gameManager.PlayerIndex);
            if(_photonView.IsMine)
            {
                _victoryJudg.SyncLIst(_gameManager.PlayerIndex);
            }
            

            Debug.Log("���ɂ܂���");
        }
    }
}
