using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject endPannel;
    public Button itemBtn1;
    public Button itemBtn2;
    public Button itemBtn3;

    public Text bestScore;
    public Text score;
    public Text endingText;
    public Text TotalScoreText;

    public Card firstCard;
    public Card secondCard;
    public Card thirdCard;

    public Animator mouseEffect01;
    public Animator mouseEffect02;
    public Animator mouseEffect03;

    public int cardCount;
    public int width;
    public int TotalScore; //카드 한 쌍 뒤집었을 시 상승하는 점수
    public float time = 0;
    public float maxTime = 30f;
    public float comboTime = 0;

    public Image timeBarFront;
    public int level = 0;

    public string key;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (PlayerPrefs.HasKey("Level"))
        {
            level = PlayerPrefs.GetInt("Level");
        }

        TotalScore = PlayerPrefs.GetInt("TotalScore"); //int 붙이면 안돼!!
        TotalScoreText.text = TotalScore.ToString(); // 문자열로써 화면에 나올 수 있도록 text, string 잊지말기
    }
    void Start()
    {
        time = maxTime;



        if (level == 1)
        {
            width = 4;
            key = "Level1";
        }
        if (level == 2)
        {
            width = 6;
            key = "Level2";
        }
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            UpdateTimeBar();
        }
        else
        {
            GameOver(key);
        }
        OnComboItem();
    }
    void UpdateTimeBar()
    {
        float ratio = time / maxTime;
        timeBarFront.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void MatchCard2()
    {
        if (firstCard.idx == secondCard.idx)
        {
            //firstCard.effectAnim.SetTrigger("Active");
            //secondCard.effectAnim.SetTrigger("Active"); //Coroutine으로 지연

            twoCardPlayMouseEffect(firstCard.transform.position, secondCard.transform.position);

            firstCard.Display();
            //firstCard = null;
            secondCard.LookCard();
            secondCard.anim.SetBool("isSuccess", true);

            Debug.Log(firstCard.gameObject.transform.position);
            secondCard.right = true;
            comboTime += 5f;
            secondCard.DestroyCardInvoke();
            cardCount -= 2;
            GameManager.instance.GetTotalScore();

            GameOver(key);
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            comboTime = 0;
        }
        firstCard = null;
        secondCard = null;
    }
    public void MatchCard3()
    {
        if (firstCard.idx == secondCard.idx && secondCard.idx == thirdCard.idx)
        {
            threeCardPlayMouseEffect02(firstCard.transform.position, secondCard.transform.position, thirdCard.transform.position);

            firstCard.DestroyCardInvoke();
            secondCard.DestroyCardInvoke();
            thirdCard.LookCard();
            thirdCard.right = true;
            thirdCard.anim.SetBool("isSuccess",true);
            comboTime += 5f;
            cardCount -= 3;
            GameManager.instance.GetTotalScore();

            GameOver(key);
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            thirdCard.CloseCard();
            comboTime = 0;
        }
        firstCard = null;
        secondCard = null;
    }

    public void GetTotalScore()
    {
        TotalScore ++;

        TotalScoreText.text = TotalScore.ToString();
    }
    public void OnComboItem()
    {
        
        if (comboTime > 0)
        {
            comboTime -= Time.deltaTime;
        }
        else
        {
            comboTime = 0;
        }
        if (comboTime > 10f)
        {
            itemBtn1.interactable = true;
            if(time < 25f)
            { 
                itemBtn2.interactable = true;
            }
            itemBtn3.interactable = true;
        }
    }

    private void twoCardPlayMouseEffect(Vector2 position1, Vector2 position2)
    {
        if (mouseEffect01 !=null && mouseEffect02 !=null)
        {
            mouseEffect01.transform.position = position1;
            mouseEffect01.SetTrigger("Active");

            mouseEffect02.transform.position = position2;
            mouseEffect02.SetTrigger("Active");
        }
    }

    private void threeCardPlayMouseEffect02(Vector2 position1, Vector2 position2, Vector2 position3)
    {
        if (mouseEffect01 !=null && mouseEffect02 !=null && mouseEffect03 != null)
        {
            mouseEffect01.transform.position = position1;
            mouseEffect01.SetTrigger("Active");

            mouseEffect02.transform.position = position2;
            mouseEffect02.SetTrigger("Active");

            mouseEffect03.transform.position = position3;
            mouseEffect03.SetTrigger("Active");
        }
    }

    public void GameOver(string key)
    {
        Debug.Log(cardCount);
        if (cardCount == 0)
        {
            score.text = key + " : " + time.ToString("N2");
            PlayerPrefs.SetInt("TotalScore", TotalScore);
            PlayerPrefs.Save();
            Debug.Log(PlayerPrefs.GetInt("TotalScore"));
            if (PlayerPrefs.HasKey(key))
            {
                float best = PlayerPrefs.GetFloat(key);
                if (time > best)
                {
                    PlayerPrefs.SetFloat(key, time);
                    bestScore.text = key + " : " + time.ToString("N2");
                }
                else
                {
                    bestScore.text = key + " : " + best.ToString("N2");
                }
            }
            else
            {
                PlayerPrefs.SetFloat(key, time);
                bestScore.text = key + " : " + time.ToString("N2");
            }
            endPannel.SetActive(true);
            Time.timeScale = 0;
        }
        if (time <= 0)
        {
            PlayerPrefs.SetInt("TotalScore", TotalScore);
            PlayerPrefs.Save();

            endPannel.SetActive(true);
            endingText.text = "FAIL...";
            Time.timeScale = 0;
        }

    }
}
