using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ItemBtn : MonoBehaviour
{
    public string triggerName = "isOpen";
    Animator[] animators;
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
}
