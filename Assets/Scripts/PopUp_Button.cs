using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static ChangeImage;

public class PopUp_Button : MonoBehaviour
{
    public GameObject TMIImage;
    public GameObject PopUpImage;


    public Image TargetImage;       // 변경할 이미지
    public Image NewImage;          // 가져올 이미지

   
    //private ChangeImage changeImage;

    

    public void OnClicked()
    {
        TMIImage.SetActive(true);
        TMIImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
        TargetImage.sprite = NewImage.sprite; // 이미지 스프라이트 교체
        int currentNum = ChangeImage.num;
        Debug.Log($"Imagenum.num 값: {currentNum}");
        

    }

    public void Backward()
    {
        PopUpImage.SetActive(false);
    }


}