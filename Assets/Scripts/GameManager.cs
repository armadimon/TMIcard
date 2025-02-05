using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public EventSystem eventSystem;

    public GameObject endPannel;
    public GameObject fadeoutPanel;
    public Animator anim;

    public Button itemBtn1;
    public Button itemBtn2;
    public Button itemBtn3;

    public Text bestScore;
    public Text score;
    public Text endingText;
    public Text countdownText;

    public Card firstCard;
    public Card secondCard;
    public Card thirdCard;
    public Board board;

    public Animator mouseEffect01;
    public Animator mouseEffect02;
    public Animator mouseEffect03;

    public int cardCount;
    public int width;
    public float time = 0;
    public float maxTime = 30f;
    public float comboTime = 0;

    public Image timeBarFront;
    public int level = 0;

    public AudioSource audioSource;
    public AudioClip clip;

    public string key;

    private bool isInteractive = false;

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
            eventSystem.enabled = false;
            StartCoroutine(StartCountdown());
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

        void Update()
        {
            if (time > 0 && isInteractive)
            {
                time -= Time.deltaTime;
                UpdateTimeBar();
            }
            if (time <= 0)
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
            twoCardPlayMouseEffect(firstCard.transform.position, secondCard.transform.position);
            audioSource.PlayOneShot(clip);
            firstCard.Display();
            board.SaveCard(firstCard);

            firstCard.anim.SetBool("isSuccess", true);
            firstCard = null;

            secondCard.LookCard();
            secondCard.anim.SetBool("isSuccess", true);

            secondCard.right = true;
            comboTime += 5f;
            secondCard.DestroyCardInvoke();
            cardCount -= 2;
            if (cardCount <= 0)
            {
                GameOver(key);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            comboTime = 0;
        }
        if (audioSource == null)
        {
            Debug.LogError("Error");
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
            board.SaveCard(thirdCard);
            thirdCard.right = true;
            thirdCard.anim.SetBool("isSuccess",true);
            comboTime += 5f;
            cardCount -= 3;
            audioSource.PlayOneShot(clip);
            if (cardCount <= 0)
            {
                GameOver(key);
            }
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
        thirdCard = null;
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

                int random = Random.Range(0, 3);
                if(random == 0)
                {
                    itemBtn1.interactable = true;
                  
                }
               else if(random == 1)
                {
                    if (time < 25f)
                    {
                        itemBtn2.interactable = true; 
                    }
                    else
                    {
                        random = Random.Range(0, 2);
                        if(random == 0)
                        {
                            itemBtn1.interactable = true;
                        }
                        else if(random == 1)
                        {
                        itemBtn3.interactable = true;
                        }
                     }
                
                }
               else if (random == 2)
                {
                    itemBtn3.interactable = true;

                }
            comboTime = 0;

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
            isInteractive = false;
            float convertTime = 30 - time;
            score.text = key + " : " + convertTime.ToString("N2") + " 초";
            if (PlayerPrefs.HasKey(key))
            {
                float best = PlayerPrefs.GetFloat(key);
                if (convertTime < best)
                {
                    PlayerPrefs.SetFloat(key, convertTime);
                    bestScore.text = key + " : " + convertTime.ToString("N2") + " 초";
                }
                else
                {
                    bestScore.text = key + " : " + best.ToString("N2") + " 초";
                }
            }
            else
            {
                PlayerPrefs.SetFloat(key, convertTime);
                bestScore.text = key + " : " + convertTime.ToString("N2") + " 초";
            }
            board.SpreadCards();
            Invoke("InvokeEndSettingSuccess", 1f);
        }
        else if (time <= 0)
        {
            if (PlayerPrefs.HasKey(key))
            {
                score.text = "FAIL...";
                float best = PlayerPrefs.GetFloat(key);
                bestScore.text = key + " : " + best.ToString("N2") + " 초";
            }
            EndSetting("FAIL...");
        }
    }
    void InvokeEndSettingSuccess()
    {
        PlayerPrefs.SetInt("GameCleared", 1);
        EndSetting("SUCCESS!");
    }

    private void EndSetting(string endMsg)
    {
        Transform xbtn = endPannel.transform.Find("XBtn");

        if (xbtn != null)
        {
            xbtn.gameObject.SetActive(false);
        }
        endPannel.SetActive(true);
        endingText.text = endMsg;
        Time.timeScale = 0;
    }
    private IEnumerator StartCountdown()
    {
        int countdown = 3;

        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f); 
            countdown--;
        }
        countdownText.text = "Start!";
        anim.SetBool("isCounting", false);
        yield return new WaitForSeconds(1.0f);
        countdownText.gameObject.SetActive(false);
        itemBtn1.onClick.Invoke();
        eventSystem.enabled = true;
        isInteractive = true;
        fadeoutPanel.SetActive(false);
    }
}
