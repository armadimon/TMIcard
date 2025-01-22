using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject endPannel;

    public Text bestScore;
    public Text score;
    public Text endingText;

    public Card firstCard;
    public Card secondCard;
    public Card thirdCard;

    public int cardCount;
    public int width;
    float time = 0;

    public Image timeBarFront;
    public float maxTime = 30f;

    public int level = 0;

    string key;

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
    }
    void UpdateTimeBar()
    {
        float ratio = time / maxTime;
        Debug.Log($"{time}, {maxTime}");
        timeBarFront.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void MatchCard2()
    {
        if (firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCardInvoke();
            secondCard.LookCard();
            secondCard.anim.SetBool("isSuccess", true);
            cardCount -= 2;
            GameOver(key);
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
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
            thirdCard.anim.SetBool("isSuccess",true);
            cardCount -= 3;
            GameOver(key);
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            thirdCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }
    public void GameOver(string key)
    {
        if (cardCount == 0)
        {
            score.text = key + " : " + time.ToString("N2");
            if (PlayerPrefs.HasKey(key))
            {
                float best = PlayerPrefs.GetFloat(key);
                if (time < best)
                {
                    PlayerPrefs.SetFloat(key, time);
                    bestScore.text = key + " : " + time.ToString("N2");
                }
                else
                {
                    bestScore.text = key + best.ToString("N2");
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
