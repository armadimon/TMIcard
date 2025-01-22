using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryButton : MonoBehaviour
{
    // 전체적으로 지피티 도움 받았으며 다시한번 확인하기
    public Button galleryButton;


    // OnEnable : SetActive true 될때마다 작동함, start는 한번만
    // 시작할때마다 세팅 함수가 작동
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