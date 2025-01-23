using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    AudioSource audioSource;
    public AudioClip clip;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GallerySeceneMusicPlay()
    {
        audioSource.clip = Resources.Load<AudioClip>($"Sound/Ukulele Beach - Doug Maxwell");
        clip = audioSource.clip;
        audioSource.Play();
    }

    public void StartSeceneMusicPlay()
    {
        audioSource.clip = Resources.Load<AudioClip>($"Sound/Goat - Wayne Jones");
        clip = audioSource.clip;
        audioSource.Play();
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
