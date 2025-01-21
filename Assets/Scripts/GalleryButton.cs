using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryButton : MonoBehaviour
{
    public void GalleryScene()
    {
        SceneManager.LoadScene("GalleryScene");
    }
}
