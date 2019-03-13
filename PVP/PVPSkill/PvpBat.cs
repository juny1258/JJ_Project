using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpBat : MonoBehaviour
{
    public GameObject Panel;

    public GameObject PlayerSkill;
    public GameObject AIBatSkill;

    public GameObject SkillEffect;

    private void Start()
    {
        Invoke("AISkill", Random.Range(0.4f, 1));
    }
    
    public void PlaySkill()
    {
        Instantiate(PlayerSkill, new Vector3(-4.65f, -2.37f, 0), Quaternion.identity);

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }

    private void AISkill()
    {
        Instantiate(AIBatSkill, new Vector3(4.65f, -2.37f, 0), new Quaternion(0, 180, 0, 0));

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }
}