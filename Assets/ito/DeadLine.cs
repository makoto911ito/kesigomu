using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

/// <summary>
/// 落ちたプレイヤーを死亡と判断するためのスクリプト
/// </summary>
public class DeadLine : MonoBehaviour
{
    [SerializeField] VictoryJudg _victoryJudg;
    [SerializeField] GameManager _gameManager;

    private void OnTriggerEnter(Collider other)
    {
        //落ちてきたオブジェクトの判別し、プレイヤーであればそのプレイヤーは死亡とする
        if(other.gameObject.CompareTag("Player"))
        {
            PhotonView _photonView = other.gameObject.GetComponent<PhotonView>();

            Debug.Log("死んだプレイヤーの番号は" + _gameManager.PlayerIndex);
            if(_photonView.IsMine)
            {
                _victoryJudg.SyncLIst(_gameManager.PlayerIndex);
            }
            

            Debug.Log("死にました");
        }
    }
}
