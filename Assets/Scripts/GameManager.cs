using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

    // Update is called once per frame
    void Update()
    {
        if (time > 0 && isInteractive)
        {
            time -= Time.deltaTime;
            UpdateTimeBar();
        }
        if (cardCount <= 0)
        {
            GameOver(key);
        }
        if (time <= 0)
        {
            EndSetting("FAIL...");
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
            board.SaveCard(firstCard);
            firstCard.anim.SetBool("isSuccess", true);
            firstCard = null;
            secondCard.anim.SetBool("isSuccess", true);
            secondCard.right = true;
            comboTime += 5f;
            secondCard.DestroyCardInvoke();
            cardCount -= 2;
            audioSource.PlayOneShot(clip);
            //GameOver(key);
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
            comboTime = 0;
        }
        if (audioSource == null)
        {
            Debug.LogError("오디오 연결안댐");
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
            audioSource.PlayOneShot(clip);
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
            board.SpreadCards();
            Invoke("InvokeEndSettingSuccess", 2f);
        }
        if (time <= 0)
        {
            EndSetting("FAIL...");
        }

    }
    void InvokeEndSettingFail()
    {
        EndSetting("FAIL...");
    }

    void InvokeEndSettingSuccess()
    {
        PlayerPrefs.SetInt("GameCleared", 1);
        EndSetting("SUCCESS!");
    }

    private void EndSetting(string endMsg)
    {
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
