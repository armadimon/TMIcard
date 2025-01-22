using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBtn : MonoBehaviour
{
    public string triggerName = "isOpen";
    Animator[] animators;
    bool falseIntercatable = true;

    public Card firstCard = null;
    public Card secondCard = null;
    public Card thirdCard = null;
    public void Look()
    {
        GameManager.instance.comboTime = 0f;
        GameManager.instance.itemBtn1.interactable = falseIntercatable;
        animators = FindObjectsOfType<Animator>();
        foreach (Animator animator in animators)
        {
            if(animator!=null)
            {
                animator.SetBool("isOpen", true);
            }
        }
        Invoke("Close", 0.5f);
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
        Card[] cards = new Card[clones.Length];

        for(int i = 0; i < clones.Length; i++)
        {
            cards[i] = clones[i].GetComponent<Card>();
        }
        if(GameManager.instance.level == 1)
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
                if (secondCard.right == false)
                {
                    secondCard.right = true;
                    firstCard.DestroyCardInvoke();
                    secondCard.anim.SetBool("isOpen", true);
                    secondCard.LookCard();
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
