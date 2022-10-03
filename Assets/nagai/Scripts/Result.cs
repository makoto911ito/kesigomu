using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;    // PunTurnManager, IPunTurnManagerCallbacks ���g������
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
            Debug.Log("�v���C���[1�̏���");
        }
        else if (PhotonNetwork.LocalPlayer.IsLocal)
        {
            Debug.Log("�v���C���[�Q�̏���");
        }
        SceneManager.LoadScene("Result");
    }
}
