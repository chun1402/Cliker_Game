using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip buySound;
    [SerializeField] private AudioClip prestigeSound;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlayClick() => sfxSource.PlayOneShot(clickSound);
    public void PlayBuy() => sfxSource.PlayOneShot(buySound);
    public void PlayPrestige() => sfxSource.PlayOneShot(prestigeSound);
}