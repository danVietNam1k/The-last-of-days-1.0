using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;
    public static AudioManager Instance => instance;
    AudioSource _audioSource;
    [SerializeField] AudioSource _defaultAudio;
    [SerializeField] AudioClip _audioShoot ,_auRealoadGun, _audioMelee,
        _auZombie,_auDialog,_auBoss,_auCoin;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        if (instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayAuInGame();
    }
    public void PlayAuBoss()
    {
        _audioSource.PlayOneShot(_auBoss);
    }
    public void PlayAuZombie()
    {
        _audioSource.PlayOneShot(_auZombie);
    }
    public void PlayAuReloadGun()
    {
        _audioSource.PlayOneShot(_auRealoadGun);
    }
    public void PlayAuShoot()
    {
        _audioSource.PlayOneShot(_audioShoot);  
    }
    public void PlayAuMelee()
    {
        _audioSource.PlayOneShot(_audioMelee);
    }
    public void PlayAuDialog()
    {
        _audioSource.PlayOneShot(_auDialog);
    }
    public void PlayAuInGame()
    {
        _defaultAudio.Play();
    }
    public void PlayAuCoin()
    {
        _audioSource.PlayOneShot(_auCoin);
    }
}
