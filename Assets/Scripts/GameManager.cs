using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text timeTxt;

    public Card firstCard;
    public Card secondCard;
    public Card thirdCard;

    public int cardCount;
    float time = 0;

    public int level = 0;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeTxt.text = time.ToString("N2");
    }
    public void MatchCard2()
    {
        if(firstCard.idx == secondCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if(cardCount == 0)
            {
                Time.timeScale = 0;
            }
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
        if (firstCard.idx == secondCard.idx && secondCard.idx ==thirdCard.idx)
        {
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            thirdCard.DestroyCard();
            cardCount -= 3;
            if (cardCount == 0)
            {
                Time.timeScale = 0;
            }
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
}
