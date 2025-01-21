using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image Image1;
    public Image Image2;
    public Image Image3;

    public void RightBittonImage()
    {
 
        Sprite sprite1 = Resources.Load<Sprite>("Images/3");
        Sprite sprite2 = Resources.Load<Sprite>("Images/4");
        Sprite sprite3 = null;

        if (Image1 != null && sprite1 != null) Image1.sprite = sprite1;
        if (Image2 != null && sprite2 != null) Image2.sprite = sprite2;
        if (Image3 != null) Image3.sprite = sprite3; 
    }

    public void LeftButtonImage()
    {

        Sprite sprite1 = Resources.Load<Sprite>("Images/0"); 
        Sprite sprite2 = Resources.Load<Sprite>("Images/1"); 
        Sprite sprite3 = Resources.Load<Sprite>("Images/2"); 

        if (Image1 != null && sprite1 != null) Image1.sprite = sprite1;
        if (Image2 != null && sprite2 != null) Image2.sprite = sprite2;
        if (Image3 != null && sprite3 != null) Image3.sprite = sprite3; 
    }
}
