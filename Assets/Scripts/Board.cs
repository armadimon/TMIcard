using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;

    public int width = 0;

    void Start()
    {
        if(GameManager.instance.level == 1)
        {
            width = 4;
        }
        else if(GameManager.instance.level == 2)
        {
            width = 6;
        }

        int maxCard = width * width;
        float cardScale = 0;
        float cardInterval = 0;

        if (width == 4)
        {
            cardScale = 1.5f;
            cardInterval = 1.8f;
        }

        if(width == 6)
        {
            cardScale = 1.0f;
            cardInterval = 1.2f;
        }

        int[] arr = new int[maxCard];
        if(width == 4)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i / 2;
            }
            arr = arr.OrderBy(x => Random.Range(0f, maxCard / 2)).ToArray();
        }
        else if(width == 6)
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

            float x = (i % width) * cardInterval - 6.7f;
            float y = (i / width) * cardInterval - 3f;
            go.transform.position = new Vector2(x, y);
            go.transform.localScale = new Vector2(cardScale, cardScale);
            go.GetComponent<Card>().Setting(arr[i]);
        }
        GameManager.instance.cardCount = arr.Length;
    }

    void Update()
    {
        
    }
}
