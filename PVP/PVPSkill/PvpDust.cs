using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpDust : MonoBehaviour
{
    public GameObject Panel;

    public GameObject PlayerSkill;
    public GameObject AISkill;

    public GameObject SkillEffect;

    private void Start()
    {
        Invoke("PlayAISkill", Random.Range(0.4f, 1));
    }
    
    public void PlaySkill()
    {
        Instantiate(PlayerSkill, new Vector3(0, 0, 0), Quaternion.identity);
        EventManager.Instance.ShackScreen(0.1f, 1f);

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }

    private void PlayAISkill()
    {
        Instantiate(AISkill, new Vector3(-5, 0, 0), Quaternion.identity);
        EventManager.Instance.ShackScreen(0.1f, 1f);

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }
}