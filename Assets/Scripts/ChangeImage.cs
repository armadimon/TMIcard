using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image Image1;
    public Image Image2;
    public Image Image3;


    public static int num = 2;

    public Text GalleryNameTxt;
    private string Name = "";

    public void RightBittonImage()
    {
        if (num <= 11)
        {
            num += 3;
        }
        else
        {
            num = 2;
        }

        Image1.sprite = Resources.Load<Sprite>("Images/" + (num - 2).ToString());
        Image2.sprite = Resources.Load<Sprite>("Images/" + (num - 1).ToString());
        Image3.sprite = Resources.Load<Sprite>("Images/" + num.ToString());
        Check();
     
    }

    public void LeftButtonImage()
    {
        if (num > 2)
        {
            num -= 3;
        }
        else
        {
            num = 14;
        }

        Image1.sprite = Resources.Load<Sprite>("Images/" + (num - 2).ToString());
        Image2.sprite = Resources.Load<Sprite>("Images/" + (num - 1).ToString());
        Image3.sprite = Resources.Load<Sprite>("Images/" + num.ToString());

        Check();
    }


    private void Check()
    {
        if (num > 11)
        {
            Name = "김영중";

        }
        else if (num > 8)
        {
            Name = "심형진";

        }
        else if (num > 5)
        {
            Name = "류은지";

        }
        else if (num > 2)
        {
            Name = "허유지";

        }
        else
        {
            Name = "안준걸";

        }

        GalleryNameTxt.text = Name + "의 갤러리";
    }

}