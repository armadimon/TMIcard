using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PopUp_Button : MonoBehaviour
{
    public GameObject TMIImage;
    public GameObject PopUpImage;
    public void OnClicked()
    {
        TMIImage.SetActive(true);
        TMIImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
    }

    public void Backward()
    {
        PopUpImage.SetActive(false);
    }


}