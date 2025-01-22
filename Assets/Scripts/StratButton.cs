using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StratButton : MonoBehaviour
{
    public void MainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void RetryLv1()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene("MainScene");
    }
    public void RetryLv2()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("MainScene");
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void GalleryScene()
    {
        SceneManager.LoadScene("GalleryScene");
    }


}
