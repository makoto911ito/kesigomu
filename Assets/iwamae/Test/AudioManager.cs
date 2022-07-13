using UnityEngine;

/// <summary>
/// �V�[���J�ڎ��̃{�^���̌��ʉ��p
/// </summary>
public class AudioManager : MonoBehaviour
{
    AudioSource _as;

    public static AudioManager Instance
    {
        get; private set;
    }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    public void PlaySE()
    {
        _as.PlayOneShot(_as.clip);
    }
}
