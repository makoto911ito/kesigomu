using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;    // PunTurnManager, IPunTurnManagerCallbacks を使うため
using Photon.Realtime;

/// <summary>
/// プレイヤーが落ちたかどうかを判定するコンポーネント
/// </summary>
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] int _deadZone = -10;
    PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (this.gameObject.transform.position.y < _deadZone)
        {
            this.gameObject.SetActive(false);
            //_view.OwnerActorNr
            //PhotonNetwork.LocalPlayer.ActorNumber
        }
    }
}
