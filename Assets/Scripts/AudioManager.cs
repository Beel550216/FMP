using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioSource audienceSource;
    [SerializeField] List<AudioClip> audienceClips = new List<AudioClip>();

    const string Music_Key = "musicVolume";
    const string SFX_Key = "sfxVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("do not destroy");
        }
        else
        {
            print("do destroy");
            Destroy(gameObject);
        }

    }

    public void AudienceSFX()
    {
        AudioClip clip = audienceClips[0];
        audienceSource.PlayOneShot(clip);
    }
}
