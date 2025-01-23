using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GalleryScene")
        {
            SoundManager.instance.GallerySeceneMusicPlay();
        }
        else if (SceneManager.GetActiveScene().name == "StartScene")
        {
            SoundManager.instance.StartSeceneMusicPlay();
        }
        else if (SceneManager.GetActiveScene().name == "MainScene")
        {
            if (SoundManager.instance.clip.name != "Goat - Wayne Jones")
            {
                SoundManager.instance.StartSeceneMusicPlay();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
