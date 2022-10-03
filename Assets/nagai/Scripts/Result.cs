using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;    // PunTurnManager, IPunTurnManagerCallbacks を使うため
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    PhotonView _view;
    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            Debug.Log("プレイヤー1の勝ち");
        }
        else if (PhotonNetwork.LocalPlayer.IsLocal)
        {
            Debug.Log("プレイヤー２の勝ち");
        }
        SceneManager.LoadScene("Result");
    }
}
