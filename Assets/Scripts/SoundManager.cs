using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class SoundManager : MonoBehaviour
{

    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    [SerializeField] private SoundType[] Sounds;

    [SerializeField] private AudioSource SoundEffect;
    [SerializeField] private AudioSource SoundMusic;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        PlayMusic(global::Sounds.Music);
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);

        if (clip != null)
        {
            SoundMusic.clip = clip; 
            SoundMusic.Play();
        }
        else
        {
            Debug.LogError("clip not found for sound type:" + sound);
        }
    }
    public void Play (Sounds sound)
    {
        AudioClip clip = getSoundClip(sound);

        if (clip != null )
        {
            SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("clip not found for sound type:" + sound);
        }
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(Sounds, i => i.soundType == sound);
        
        if (item != null )
        return item.OrgSoundClip;
        return null;
    }
}

    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip OrgSoundClip;
    }

    public enum Sounds
    {
        ButtonClick,
        Music,
        PlayerMove,
        PlayerDeath,
        EnemyDeath,
    }












