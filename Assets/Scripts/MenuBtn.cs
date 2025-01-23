using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBtn : MonoBehaviour
{
    public GameObject endPannel;

    public void OnMenu()
    {
        endPannel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void OffMenu()
    {
        endPannel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
