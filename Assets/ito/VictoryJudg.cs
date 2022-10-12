using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

/// <summary>
/// 勝利判定をして画面に勝利者を出すためのスクリプト
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
        //デバック用
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("プレイヤーの最大数は" + _playersList.Count + "人");

            foreach (var i in _playersList)
            {
                Debug.Log("現在残っているプレイヤーの番号は" + i + "番");
            }
        }
    }

    /// <summary>リストの同期を行う関数</summary>
    /// <param name="playernum">プレイヤーの番号</param>
    public void SyncLIst(int playernum)
    {
        object[] _parameter = new object[] { playernum };
        _photonView.RPC("RemoveList", RpcTarget.All, _parameter);
    }

    /// <summary>
    /// 引数に受け取ったプレイヤーの番号と同じ番号を_playersListから消去する関数
    /// </summary>
    /// <param name="playernum">プレイヤーの番号</param>
    [PunRPC]
    void RemoveList(int playernum)
    {
        _playersList.Remove(playernum);
    }

    /// <summary>
    /// _playersListを初期化するための関数
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
        Debug.Log("判定中");

        if (_playersList.Count == 1)
        {
            _text.text = _playersList[0] + "の勝利".ToString();
        }
        else if(_playersList.Count == 0)
        {
            _text.text = "引き分け".ToString();
        }
    }
}
