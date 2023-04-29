using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource _bgmPrefab;
    [SerializeField] AudioSource _sfxPrefab;

    [SerializeField] AudioClip[] _bgmClips;

    AudioSource _bgm;
    AudioSource _sfx;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

        _bgm = Instantiate( _bgmPrefab );
        DontDestroyOnLoad(_bgm);

        _sfx = Instantiate(_sfxPrefab);
        DontDestroyOnLoad(_sfx);
    }

    void OnDestroy()
    {
        if (this == instance)
        {
            instance = null;

            if (_bgm != null)
            {
                Destroy(_bgm.gameObject);
            }

            if (_sfx != null)
            {
                Destroy(_sfx.gameObject);
            }
        }
    }

    public void PlayBGM(int index)
    {
        if (_bgm.clip == _bgmClips[index])
        {
            return;
        }

        _bgm.clip = _bgmClips[index];
        _bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfx.PlayOneShot(clip);
    }
}
