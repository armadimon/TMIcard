using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image Image1;
    public Image Image2;
    public Image Image3;

    public static int num = 2;


    public void RightBittonImage()
    {
        if(num<=11)
        {
            num += 3;
        }
   
        Image1.sprite = Resources.Load<Sprite>("Images/" + (num-2).ToString());
        Image2.sprite = Resources.Load<Sprite>("Images/" + (num-1).ToString());
        Image3.sprite = Resources.Load<Sprite>("Images/" + num.ToString());


    }

    public void LeftButtonImage()
    {
        if(num>2)
        {
            num -= 3;
        }

        Image1.sprite = Resources.Load<Sprite>("Images/" + (num - 2).ToString());
        Image2.sprite = Resources.Load<Sprite>("Images/" + (num - 1).ToString());
        Image3.sprite = Resources.Load<Sprite>("Images/" + num.ToString());


    }
}
