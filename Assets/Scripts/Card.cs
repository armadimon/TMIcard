using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;
    public bool right = false;

    public Animator anim;
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
    }
    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        if (GameManager.instance.firstCard == null)
        {
            GameManager.instance.firstCard = this;
        }
        else if(GameManager.instance.secondCard == null)
        {
            GameManager.instance.secondCard = this;
            if (GameManager.instance.level == 1)
            { 
                GameManager.instance.MatchCard2();
            }
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

    public void LookCard()
    {
        float x = Random.Range(1.2f, 8.0f);
        float y = Random.Range(-0.8f, -2.7f);
        float scale = Random.Range(0.5f, 1.1f); ;
        gameObject.transform.position = new Vector2(x, y);
        gameObject.transform.localScale *= scale;
    }
}
