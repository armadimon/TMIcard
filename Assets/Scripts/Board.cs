using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

public class Board : MonoBehaviour
{
    public GameObject card;

    int width = 0;
    int level = 0;
    float cardScale = 0;
    float cardInterval = 0;
    float genOffsetX = 0.0f;
    float genOffsetY = 0.0f;

    Card[] cardList = new Card[36];
    void Start()
    {
        level = GameManager.instance.level;
        width = GameManager.instance.width;

        int maxCard = width * width;


        if (level ==1)
        {
            cardScale = 1.5f;
            cardInterval = 1.8f;
        }
        else if(level == 2)
        {
            cardScale = 1.0f;
            cardInterval = 1.2f;
            genOffsetX = 0.3f;
            genOffsetY = 0.2f;
        }

        int[] arr = new int[maxCard];
        if(level == 1)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i / 2;
            }
            arr = arr.OrderBy(x => Random.Range(0f, maxCard / 2)).ToArray();
        }
        else if(level == 2)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i / 3;
            }
            arr = arr.OrderBy(x => Random.Range(0f, maxCard / 3)).ToArray();
        }

        for (int i = 0; i < maxCard; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % width) * cardInterval - 6.7f - genOffsetX;
            float y = (i / width) * cardInterval - 3f - genOffsetY;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(cardScale, cardScale);
            go.GetComponent<Card>().Setting(arr[i]);
        }
        GameManager.instance.cardCount = arr.Length;
    }

    public void SaveCard(Card card)
    {
        for (int i = 0; i < cardList.Length; i++)
        {
            if (cardList[i] == null)
            {
                cardList[i] = card;
                return;
            }
        }
    }

    public void SpreadCards()
    {
        for (int i = 0; i < cardList.Length; i++)
        {
            if (cardList[i] != null)
            {
                float x = (i % width) * cardInterval + 2.2f - genOffsetX;
                float y = (i / width) * cardInterval + - genOffsetY;
                cardList[i].Display(new Vector3(0, 0, 0), new Vector3(x, y, 0));
            }
        }
    }
    public void SpreadCards2()
    {
        for (int i = 0; i < cardList.Length; i++)
        {
            if (cardList[i] != null)
            {
                float x = (i % width) * cardInterval + 2.2f - genOffsetX;
                float y = (i / width) * cardInterval + -genOffsetY;
                cardList[i].Display(new Vector3(0, 0, 0), new Vector3(x, y, 0));
            }
        }
    }
    void Update()
    {
        
    }
}
