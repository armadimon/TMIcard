using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public Animator anim;
    public GameObject front;
    public GameObject back;
    public SpriteRenderer frontimage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontimage.sprite = Resources.Load<Sprite>($"Images/{idx}");
        Debug.Log($"{idx}, {frontimage.sprite}");
    }
    public void OpenCard()
    {
        Debug.Log(anim);
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
        if (GameManager.instance.firstCard == null)
        {
            GameManager.instance.firstCard = this;
        }
        else if(GameManager.instance.secondCard == null)
        {
            GameManager.instance.secondCard = this;
            if (GameManager.instance.level == 1)
            { GameManager.instance.MatchCard2(); }
        }
        else
        {
            GameManager.instance.thirdCard = this;
            GameManager.instance.MatchCard3();
        }
    }
    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }
    public void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }
    public void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
    }
}
