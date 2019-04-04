using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet2Skill : MonoBehaviour
{
    public Animator animator;
    
    public void PlaySkill1()
    {
        animator.Play("41", 0, 0);
    }

    public void PlaySkill2()
    {
        animator.Play("2", 0, 0);
    }

    public void PlaySkill3()
    {
        animator.Play("28", 0, 0);
    }
    
    public void PlaySkill4()
    {
        animator.Play("38", 0, 0);
    }

    public void PlaySkill5()
    {
        animator.Play("15", 0, 0);
    }
    
    public void PlaySkill6()
    {
        animator.Play("9", 0, 0);
    }
}
