using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f, 1f)] float shootingVolume;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume;

    static AudioPlayer instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void PlayerShootingClip()
    {
        if (shootingClip != null)
            PlaySound(shootingClip, shootingVolume);
    }

    public void DamageClip()
    {

        PlaySound(damageClip, damageVolume);
    }

    void PlaySound(AudioClip audioClip, float volume)
    {
        Vector3 camPos = Camera.main.transform.position;
        if (audioClip != null)
            AudioSource.PlayClipAtPoint(audioClip, camPos, volume);
    }
}
