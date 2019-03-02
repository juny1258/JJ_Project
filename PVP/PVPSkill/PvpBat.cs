using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpBat : MonoBehaviour
{
    public GameObject Panel;

    public GameObject PlayerSkill;
    public GameObject AIBatSkill;

    public GameObject SkillEffect;

    private bool isClick;
    private float skillTime;

    private void Start()
    {
        Invoke("AISkill", DataController.Instance.AIData.skillClickTime);
    }

    private void Update()
    {
        if (!isClick)
        {
            skillTime += Time.deltaTime;
        }
    }

    public void PlaySkill()
    {
        isClick = true;
        Instantiate(PlayerSkill, new Vector3(-4.65f, -2.37f, 0), Quaternion.identity);

        DataController.Instance.PlayerData.skillClickTime = skillTime;

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }

    private void AISkill()
    {
        isClick = true;
        Instantiate(AIBatSkill, new Vector3(4.65f, -2.37f, 0), new Quaternion(0, 180, 0, 0));

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }
}