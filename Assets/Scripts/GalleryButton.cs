using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryButton : MonoBehaviour
{
    public Button galleryButton;

    private void Start()
    {
        galleryButton = GetComponent<Button>();
        Setting();
    }

    public void Setting()
    {
        if (PlayerPrefs.HasKey("GameCleared") && PlayerPrefs.GetInt("GameCleared") == 1)
        {
            galleryButton.interactable = true;
        }
        else
        {
            galleryButton.interactable = false;
        }

    }
    public void GalleryScene()
    {
        SceneManager.LoadScene("GalleryScene");
    }
}