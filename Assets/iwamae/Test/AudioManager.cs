using UnityEngine;

/// <summary>
/// シーン遷移時のボタンの効果音用
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
