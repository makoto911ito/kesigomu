using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの名前を呼び出す使用例
/// </summary>
public class TestSetting : MonoBehaviour
{
    [Tooltip("プレイヤーの名前のテキスト")]
    [SerializeField] Text _playername = default;

    void Start()
    {
        _playername.text = PlayerNameInput._playerNameStr;
    }
}
