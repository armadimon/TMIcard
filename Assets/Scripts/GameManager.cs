using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Card firstCard;
    public Card secondCard;
    public Card thirdCard;

    public int cardCount;
    public int width;
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
            firstCard.Display();
            firstCard = null;
            secondCard.LookCard();
            secondCard.anim.SetBool("isSuccess", true);
            secondCard.right = true;
            comboTime += 5f;
            secondCard.DestroyCardInvoke();
            cardCount -= 2;
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
            firstCard.DestroyCardInvoke();
            secondCard.DestroyCardInvoke();
            thirdCard.LookCard();
            thirdCard.right = true;
            thirdCard.anim.SetBool("isSuccess",true);
            comboTime += 5f;
            cardCount -= 3;
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
    public void GameOver(string key)
    {
        if (cardCount == 0)
        {
            //게임 클리어가 되었는지
            PlayerPrefs.SetInt("GameCleared", 1);
            //게임이 종료되어도 남아있게 하는 코드 
            //PlayerPrefs.Save();

            score.text = key + " : " + time.ToString("N2");
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
            endPannel.SetActive(true);
            endingText.text = "FAIL...";
            Time.timeScale = 0;
        }

    }
}
