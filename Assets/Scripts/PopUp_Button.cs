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


    public Image TargetImage;       // ������ �̹���
    public Image NewImage;          // ������ �̹���

   
    //private ChangeImage changeImage;

    

    public void OnClicked()
    {
        TMIImage.SetActive(true);
        TMIImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
        TargetImage.sprite = NewImage.sprite; // �̹��� ��������Ʈ ��ü
        int currentNum = ChangeImage.num;
        Debug.Log($"Imagenum.num ��: {currentNum}");
        

    }

    public void Backward()
    {
        PopUpImage.SetActive(false);
    }


}