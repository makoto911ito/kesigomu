using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̖��O��ݒ肷��
/// </summary>
public class PlayerNameInput : MonoBehaviour
{
    [Tooltip("�v���C���[�̓���ɕ\������閼�O")]
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
        Debug.Log($"���̖��O��{_playerName.text}�ł�");
        //AudioManager.Instance.PlaySE();
        //Debug.Log("���o��");
        _playerNameStr = _playerName.text;
        //GetComponent<SceneChanger>().ChangeScene("lobby");
    }
}
