using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBtn : MonoBehaviour
{
    public string triggerName = "isOpen";
    Animator[] animators;
    Card card;
    public void Look()
    {
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
            GameManager.instance.time += 5.0f;
            GameManager.instance.comboTime = 0f;
            GameManager.instance.itemBtn2.interactable = false;
    }


}
