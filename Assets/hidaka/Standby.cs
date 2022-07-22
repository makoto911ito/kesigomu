using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Standby : MonoBehaviour
{
    [SerializeField] Text playerName = null; //待機中プレイヤー表示
    [SerializeField] string[] waitPlayer = null;
    [SerializeField] Text waitText = null;//待機児表示文字
    [SerializeField] Text back = null; //戻るボタン まだ
    [SerializeField] GameObject wait = null;
    bool waitFlag = false; //待機画面を表示するか否か
    float time = 0; //点滅速度
    int playerCount = 0;
    void Start()
    {
        wait = GetComponent<GameObject>();
    }


    void Update()
    {
        time += Time.deltaTime;

        //スポーンポイントの数をMaxとする
        GameObject[] sp = GameObject.FindGameObjectsWithTag("Untagged");
        GameObject[] pl = GameObject.FindGameObjectsWithTag("Player");
        if (playerCount < sp.Length - 1) //プレイヤーがスポーンポイント数に満たない場合
        {
            waitFlag = true;
            waitText.text = "待機中...";
            playerName.text = PlayerNameInput._playerNameStr;
        }
        else
        {
            waitText = null;
            waitFlag = false;
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
}
