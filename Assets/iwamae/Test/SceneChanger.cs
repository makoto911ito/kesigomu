using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���J�ڂ���
/// �e�X�g�p
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
