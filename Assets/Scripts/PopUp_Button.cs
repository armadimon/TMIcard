using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    public Text FirstTxt;
    public Text SecondTxt;
    

    string Name = "";
    string TMI = "";

    private ChangeImage changeImage;



    public void OnClicked()
    {
        TMIImage.SetActive(true);
        TMIImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
        TargetImage.sprite = Resources.Load<Sprite>("Images/Gallary_Ver_Image/"+NewImage.sprite.name); // �̹��� ��������Ʈ ��ü
        int currentNum = ChangeImage.num;
        Debug.Log($"Imagenum.num ��: {currentNum}"); // Ŭ������ ChangeImage�� num�� �ޱ�




        changeImage = FindObjectOfType<ChangeImage>();

        Image TMIimage1 = changeImage.Image1;
        Image TMIimage2 = changeImage.Image2;
        Image TMIimage3 = changeImage.Image3;


        if (currentNum>11)
        {
            Name = "�迵��";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "��� ������ �߾��� �� ������ �̶��� ���ư��� �ͳ׿�.";
            }
            else if(TargetImage.sprite.name == TMIimage2.sprite.name)
            {
                TMI = "����� ������ ¯���� ��ġ�ϴٰ� �����ߴµ� ������ ¯���� ��ս��ϴ�.";
            }
            else if (TargetImage.sprite.name == TMIimage3.sprite.name)
            {
                TMI = "�ƹ߷�";
            }
        }
        else if(currentNum>8) 
        {
            Name = "������";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "����) ������ �ٸ��ϴ�.\n������ ������ �� ���� Ȧ����";
            }
            else if (TargetImage.sprite.name == TMIimage2.sprite.name)
            {
                TMI = "";
            }
            else if (TargetImage.sprite.name == TMIimage3.sprite.name)
            {
                TMI = "";
            }
        }
        else if(currentNum>5)
        {
            Name = "������";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "������ ù��° TMI\n�ܹ��� �Ⱦ��� ��Ӹ��� �����Ӹ��� �����ϰ� �ְ� �̸��� ������\n�ֺ� ���ε��� �� �̸����� �౸�� ���� �� �� ���ٰ� ���Ѵ�";
            }
            else if (TargetImage.sprite.name == TMIimage2.sprite.name)
            {
                TMI = "������ �ι�° TMI\r\n\r\n���ӵ� ���������� �����Ҷ� ���� Ű���� Ŀ���Ұ� (�Ϳ���)���� ������ ����̸�\r\n\r\nŰ���� Ŀ������ �ʺ��� �μ����� �ְ� ���嵵 ���� �����߿� ��� �Ҹ�ģ���� �ִ�.";
            }
            else if (TargetImage.sprite.name == TMIimage3.sprite.name)
            {
                TMI = "������ ����° TMI\r\n\r\n���� ���� �����Ѵ�, �ָ����� 12�ð��� �ڱ⵵ �Ѵ�.\r\n\r\n�Դ°͵� ���� �����Ѵ�. ���� ���� ���� �Դ°ɷ� ���µ� �ߴ�.\r\n\r\n���� �Ḹ���ΰ� ����.";
            }
        }
        else if (currentNum>2) 
        {
            Name = "������";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "�� ������ ȫ�� ��Ʃ������� 12���� ���� ���� �����̴�.\r\n\r\n����Բ� ������ ���ִٰ� Ī���޾����� ��Ÿ���Ե� �Բ� �������� ���ߴ�.";
            }
            else if (TargetImage.sprite.name == TMIimage2.sprite.name)
            {
                TMI = "ħ���� �ҽ���ȸ�� ��÷�� ���� �ִ�.\r\n\r\nħ���� ���� ���� ���� 14���� �귶��. ��Ŷ����Ʈ�� ä�� �� �־� �ູ�ߴ� �����̾���.\r\n��¥ �߻���� Ű�� ū�� ī�޶� ������ ���� ���Ѵٴ°� �����.";
            }
            else if (TargetImage.sprite.name == TMIimage3.sprite.name)
            {
                TMI = "���� ���̴� ĳ���Ͱ� ������ �־� ĳ����.\r\n\r\n�Ҵ� �ƴϰ� �Ҵ� ģ�� �������.\r\n\r\n�����Ͱ��� ����.";
            }
        }
        else
        {
            Name = "���ذ�";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "���տ��� ���ͼ� ����� ��ī�Դϴ�. ���������� �𸣰ڳ׿�.";
            }
            else if (TargetImage.sprite.name == TMIimage2.sprite.name)
            {
                TMI = "���� ����� �����Դϴ�. ����� �� ���� �����ϴ� ������ �� �ϳ��Դϴ١�";
            }
            else if (TargetImage.sprite.name == TMIimage3.sprite.name)
            {
                TMI = "�� ��ġ�� ���� �����Դϴ�.\r\n\r\n�Ϳ���?";
            }
        }

        
        FirstTxt.text = Name;
        SecondTxt.text = TMI;
    }

    public void Backward()
    {
        PopUpImage.SetActive(false);
    }


}