using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayeName : MonoBehaviour
{
    Text _name;
    string _playerNamestr;// ���̃X�N���v�g���玝���Ă���

    // Start is called before the first frame update
    void Start()
    {
        _name.text = _playerNamestr;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
