using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移する
/// テスト用
/// </summary>
public class SceneChanger : MonoBehaviour
{
    AudioSource _as;

    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    public void ChangeScene(string name)
    {
        AudioManager am = AudioManager.Instance;
        am.PlaySE();
        SceneManager.LoadScene(name);
    }
}
