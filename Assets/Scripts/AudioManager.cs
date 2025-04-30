using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioMixer mixer;

    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource backgroundSource;
    [SerializeField] List<AudioClip> sfxClips = new List<AudioClip>();
    

    public const string Music_Key = "musicVolume";
    public const string SFX_Key = "sfxVolume";

    void Awake()
    {
        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            print("do not destroy");
        }
        else
        {
            print("do destroy");
            Destroy(gameObject);
        }*/

        LoadVolume();

    }

    void Start()
    {
        backgroundSource.Play();
    }

    public void playSFX(int num)
    {
        AudioClip clip = sfxClips[num];
        sfxSource.PlayOneShot(clip);
    }


    void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(Music_Key, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_Key, 1f);

        mixer.SetFloat(VolumeSettings.Mixer_Music, Mathf.Log10(musicVolume)* 20);
        mixer.SetFloat(VolumeSettings.Mixer_SFX, Mathf.Log10(sfxVolume)* 20);
    }
}
