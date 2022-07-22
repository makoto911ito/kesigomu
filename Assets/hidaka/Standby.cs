using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Standby : MonoBehaviour
{
    [SerializeField] Text waitPlayer = null; //待機中プレイヤー表示
    [SerializeField] Text waitText = null;//待機児表示文字
    [SerializeField] Text back = null; //戻るボタン まだ
    [SerializeField] GameObject wait = null;
    bool waitFlag = false; //待機画面を表示するか否か
    float time = 0;
    int playerCount = 0;
    void Start()
    {
        
    }


    void Update()
    {
        time += Time.deltaTime;
        //if()
        wait = GetComponent<GameObject>();

        //待機文字の点滅
        var alpha = Mathf.Cos(2 * Mathf.PI * time / 2) * 0.5f + 0.5f;
        var color = waitText.color;
        color.a = alpha;
        waitText.color = color;

        //if (playerCount < NetworkGameManagerTurnBased._maxPlayers) //PlayerタグのObjの数がMaxに満たない場合
        //{
        //    waitFlag = true;
        //    waitText.text = "待機中...";
        //    waitPlayer.text = PlayerNameInput._playerNameStr;
        //}
        //else
        //{
        //    waitText = null;
        //    waitFlag = false;
        //}

        //public void ChangeScene(Scene scene) => SceneManager.LoadScene("Title");
    }
}
