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

    

    public Image TargetImage;       // 변경할 이미지
    public Image NewImage;          // 가져올 이미지

    public Text FirstTxt;
    public Text SecondTxt;
    

    string Name = "";
    string TMI = "";

    private ChangeImage changeImage;



    public void OnClicked()
    {
        TMIImage.SetActive(true);
        TMIImage.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
        TargetImage.sprite = Resources.Load<Sprite>("Images/Gallary_Ver_Image/"+NewImage.sprite.name); // 이미지 스프라이트 교체
        int currentNum = ChangeImage.num;
        Debug.Log($"Imagenum.num 값: {currentNum}"); // 클래스로 ChangeImage에 num값 받기




        changeImage = FindObjectOfType<ChangeImage>();

        Image TMIimage1 = changeImage.Image1;
        Image TMIimage2 = changeImage.Image2;
        Image TMIimage3 = changeImage.Image3;


        if (currentNum>11)
        {
            Name = "김영중";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "운동을 열심히 했얼을 때 같은데 이때로 돌아가고 싶네요.";
            }
            else if(TargetImage.sprite.name == TMIimage2.sprite.name)
            {
                TMI = "어렸을 적에는 짱구가 유치하다고 생각했는데 요즘은 짱구가 재밌습니다.";
            }
            else if (TargetImage.sprite.name == TMIimage3.sprite.name)
            {
                TMI = "훈발롬";
            }
        }
        else if(currentNum>8) 
        {
            Name = "심형진";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "주의) 실제와 다릅니다.\n지금은 생각할 수 없는 홀쪽함";
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
            Name = "류은지";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "은지의 첫번째 TMI\n단발이 안어울려 긴머리에 갈색머리를 고집하고 있고 이마가 넓은데\n주변 지인들은 내 이마에서 축구도 가능 할 것 같다고 말한다";
            }
            else if (TargetImage.sprite.name == TMIimage2.sprite.name)
            {
                TMI = "은지의 두번째 TMI\r\n\r\n게임도 좋아하지만 게임할때 쓰는 키보드 커스텀과 (귀여운)굿즈 수집이 취미이며\r\n\r\n키보드 커스텀은 초보라 부순적도 있고 고장도 내서 게임중에 몇번 소리친적이 있다.";
            }
            else if (TargetImage.sprite.name == TMIimage3.sprite.name)
            {
                TMI = "은지의 세번째 TMI\r\n\r\n잠을 정말 좋아한다, 주말에는 12시간씩 자기도 한다.\r\n\r\n먹는것도 정말 좋아한다. 버는 돈의 반이 먹는걸로 들어가는듯 했다.\r\n\r\n나는 잠만보인가 보다.";
            }
        }
        else if (currentNum>2) 
        {
            Name = "허유지";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "이 사진은 홍대 스튜디오에서 12만원 내고 찍은 사진이다.\r\n\r\n사장님께 바지가 멋있다고 칭찬받았으나 안타깝게도 함께 찍히지는 못했다.";
            }
            else if (TargetImage.sprite.name == TMIimage2.sprite.name)
            {
                TMI = "침착맨 팬싸인회에 당첨된 적이 있다.\r\n\r\n침착맨 팬이 된지 벌써 14년이 흘렀다. 버킷리스트를 채울 수 있어 행복했던 순간이었다.\r\n진짜 잘생겼고 키도 큰데 카메라가 온전히 담지 못한다는게 슬펐다.";
            }
            else if (TargetImage.sprite.name == TMIimage3.sprite.name)
            {
                TMI = "옆에 보이는 캐릭터가 본인의 최애 캐릭터.\r\n\r\n소닉 아니고 소닉 친구 섀도우다.\r\n\r\n베지터같은 성격.";
            }
        }
        else
        {
            Name = "안준걸";
            if (TargetImage.sprite.name == TMIimage1.sprite.name)
            {
                TMI = "집앞에서 나와서 찍었던 셀카입니다. 언제인지는 모르겠네요.";
            }
            else if (TargetImage.sprite.name == TMIimage2.sprite.name)
            {
                TMI = "저의 깃허브 사진입니다. 어렸을 때 제일 좋아하던 디지몬 중 하나입니다…";
            }
            else if (TargetImage.sprite.name == TMIimage3.sprite.name)
            {
                TMI = "제 유치원 시절 사진입니다.\r\n\r\n귀엽죠?";
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