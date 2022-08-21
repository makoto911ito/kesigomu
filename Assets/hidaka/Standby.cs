using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Standby : MonoBehaviour
{
    [SerializeField] Text playersName = null;
    [SerializeField] Text memberText = null;
    [SerializeField] Text waitText = null;//待機児表示文字
    [SerializeField] Text back = null; //戻るボタン まだ
    [SerializeField] GameObject wait = null;
    bool waitFlag = false; //待機画面を表示するか否か
    float time = 0; //点滅速度
    [SerializeField] GameObject spornPoiunt;
    List<GameObject> sp = new List<GameObject>();
    GameObject[] pl;
    void Start()
    {
        wait = GetComponent<GameObject>();
    }


    void Update()
    {
        time += Time.deltaTime;

        //スポーンポイントの数をMaxとする
        //GameObject[] sp = GameObject.FindGameObjectsWithTag("Finish");
        pl = GameObject.FindGameObjectsWithTag("Player");
        

        //プレイヤーがスポーンポイント数に満たない場合
        if (pl.Length == sp.Count) waitFlag = false;
        else
        {
            waitFlag = true;
            waitText.text = "待機中...";
        }

        //待機文字の点滅
        var alpha = Mathf.Cos(2 * Mathf.PI * time / 2) * 0.5f + 0.5f;
        var color = waitText.color;
        color.a = alpha;
        waitText.color = color;

        if(waitFlag == false)
        {
            Destroy(wait);
        }

        //public void ChangeScene(Scene scene) => SceneManager.LoadScene("Title");
    }
    void Character()
    {
        memberText.text = "待機中のプレイヤー\n" + pl.Length + "/" + sp.Count;
        playersName.text += "Player" + pl.Length + ":" + pl[pl.Length - 1].name + "\n";

    }
}
