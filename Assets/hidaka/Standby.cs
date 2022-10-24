using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Standby : MonoBehaviour
{
    [SerializeField] Text numberText = null;
    [SerializeField] Text waitText = null;//待機児表示文字
    [SerializeField] Text back = null;
    bool waitFlag = false; //待機画面を表示するか否か
    float time = 0; //点滅速度
    [SerializeField] List<GameObject> sp = new List<GameObject>();
    [SerializeField] GameObject[] pl;
    [SerializeField] int plNum = 0; //以前のプレイヤー数



    void Update()
    {
        pl = GameObject.FindGameObjectsWithTag("Player");
        Func<int, int, string> nowText = (ply, spl) => { return ply + "人 / " + spl + "人中"; }; //現在の人数と
            numberText.text = $"{nowText(pl.Length, sp.Count)}";

        

        time += Time.deltaTime;

        //プレイヤーがスポーンポイント数に満たない場合
        if (pl.Length == sp.Count) waitFlag = true;
        else
        {
            waitFlag = false;
            waitText.text = "待機中...";
        }

        //待機文字の点滅
        var alpha = Mathf.Cos(2 * Mathf.PI * time / 2) * 0.5f + 0.5f;
        var color = waitText.color;
        color.a = alpha;
        waitText.color = color;
        if(waitFlag == true)
        {
            Destroy(this.gameObject);
        }
    }
}
