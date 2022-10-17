using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Teut : MonoBehaviour
{
    Rigidbody _rb;
    PhotonView _photonView;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_photonView.IsMine)
        {
            Debug.Log("ç°ÇÃë¨ìxÇÕ" + _rb.velocity.magnitude);
        }
    }
}
