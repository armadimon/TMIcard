using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBtn : MonoBehaviour
{
    public string triggerName = "isOpen";
    Animator[] animators;
    public bool falseIntercatable = false; // 테스트용

    public Card firstCard = null;
    public Card secondCard = null;
    public Card thirdCard = null;

    public Board board;

    public void Look()
    {
        GameManager.instance.comboTime = 0f;
        GameManager.instance.itemBtn1.interactable = falseIntercatable;
        animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators)
        {
            if (animator!=null && animator.name != "FadeoutPanel")
            {
                animator.SetBool("isOpen", true);
            }
        }
        Invoke("Close", 2.0f);
    }
    private void Close()
    {
        foreach (Animator animator in animators)
        {
            if (animator != null)
            {
                animator.SetBool("isOpen", false);
            }
        }
    }

    public void TimeUp()
    {
        GameManager.instance.comboTime = 0f;
        GameManager.instance.itemBtn2.interactable = falseIntercatable;
        GameManager.instance.time += 5.0f;
    }

    public void RandomBreak()
    {
        GameManager.instance.comboTime = 0f;
        GameManager.instance.itemBtn3.interactable = falseIntercatable;
        GameObject[] clones = GameObject.FindGameObjectsWithTag("Card");
        List<Card> cards = new List<Card>();
        int j = 0;
        for (int i = 0; i < clones.Length; i++)
        {
            Card tempCard = clones[i].GetComponent<Card>();
            if (tempCard.anim.GetBool("isSuccess") == false)
            {
                cards.Add(tempCard);
                j++;
            }
        }
        if(GameManager.instance.level == 1)
        {
            while (GameManager.instance.cardCount != 0)
            {
                int ranNum = Random.Range(0, cards.Count);
                firstCard = cards[ranNum];
                for (int i = 0; i < cards.Count - 1; i++)
                {
                    if (firstCard.idx == cards[i].idx && firstCard != cards[i])
                    {
                        secondCard = cards[i];
                    }
                }
                if (secondCard.right == false)
                {
                    secondCard.right = true;
                    secondCard.Display();
                    board.SaveCard(secondCard);
                    firstCard.DestroyCardInvoke();
                    secondCard.anim.SetBool("isSuccess", true);
                    secondCard.anim.SetBool("isOpen", true);
                    GameManager.instance.cardCount -= 2;
                    if (GameManager.instance.cardCount == 0)
                    {
                        GameManager.instance.GameOver(GameManager.instance.key);
                    }
                    break;
                }
            }
        }
        else if (GameManager.instance.level == 2)
        {
            while (GameManager.instance.cardCount != 0)
            {
                int ranNum = Random.Range(0, clones.Length);
                firstCard = cards[ranNum];
                for (int i = 0; i < clones.Length; i++)
                {
                    if (firstCard.idx == cards[i].idx && firstCard != cards[i])
                    {
                        secondCard = cards[i];
                    }
                }
                for (int i = 0; i < clones.Length; i++)
                {
                    if (firstCard.idx == cards[i].idx && firstCard != cards[i] && secondCard != cards[i])
                    {
                        thirdCard = cards[i];
                    }
                }
                if (thirdCard.right == false)
                {
                    thirdCard.right = true;
                    firstCard.DestroyCardInvoke();
                    secondCard.DestroyCardInvoke();
                    thirdCard.anim.SetBool("isOpen", true);
                    thirdCard.LookCard();
                    board.SaveCard(thirdCard);

                    GameManager.instance.cardCount -= 3;
                    if (GameManager.instance.cardCount == 0)
                    {
                        GameManager.instance.GameOver(GameManager.instance.key);
                    }
                    break;
                }
            }
        }
    }
}
