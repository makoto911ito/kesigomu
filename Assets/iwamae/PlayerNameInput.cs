using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの名前を設定する
/// </summary>
public class PlayerNameInput : MonoBehaviour
{
    [Tooltip("プレイヤーの頭上に表示される名前")]
    [SerializeField] InputField _playerName = default;
    public static string _playerNameStr = "";
    //public static AudioSource _as;
    Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        //_as = GetComponent<AudioSource>();
        _button.onClick.AddListener(() => SetName());
    }

    void Update()
    {
        if (string.IsNullOrWhiteSpace(_playerName.text))
        {
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
        }       
    }

    public void SetName()
    {
        Debug.Log($"私の名前は{_playerName.text}です");
        //AudioManager.Instance.PlaySE();
        //Debug.Log("音出た");
        _playerNameStr = _playerName.text;
        //GetComponent<SceneChanger>().ChangeScene("lobby");
    }
}
