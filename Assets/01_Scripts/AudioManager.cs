using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Singleton
    public static AudioManager Instance { get; set; }

    public AudioClip[] bgmClips;
    public float bgmVolume;
    AudioSource bgmPlayer;

    public AudioMixerGroup bgmMixerGroup;

    private long tick;
    private float timeSeed;

    private void Awake()
    {
        // ΩÃ±€≈Ê
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }

        Init();

        // Init Random Seed
        tick = DateTime.Now.Ticks;
        timeSeed = (int)(tick % int.MaxValue);
        UnityEngine.Random.InitState((int)timeSeed);
    }

    void Update()
    {
        if (!bgmPlayer.isPlaying)
        {
            RandomBGM();
        }
    }

    void Init()
    {
        // BGM Player Initialize
        GameObject bgmObject = new GameObject("bgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.outputAudioMixerGroup = bgmMixerGroup;
    }
    /*
    public void PlayBgm(bool isPlay)
    {
        if (isPlay) {
            bgmPlayer.Play();
        }
        else {
            bgmPlayer.Pause();
        }
    }*/

    private void RandomBGM()
    {
        bgmPlayer.clip = bgmClips[UnityEngine.Random.Range(0, bgmClips.Length)];
        bgmPlayer.Play();
    }
}
