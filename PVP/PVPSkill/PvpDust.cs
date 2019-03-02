using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpDust : MonoBehaviour
{
    public GameObject Panel;

    public GameObject PlayerSkill;
    public GameObject AISkill;

    private bool isClick;
    private float skillTime;

    public GameObject SkillEffect;

    private void Start()
    {
        Invoke("PlayAISkill", DataController.Instance.AIData.skillClickTime);
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
        Instantiate(PlayerSkill, new Vector3(0, 0, 0), Quaternion.identity);
        EventManager.Instance.ShackScreen(0.1f, 1f);

        DataController.Instance.PlayerData.skillClickTime = skillTime;

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }

    private void PlayAISkill()
    {
        isClick = true;
        Instantiate(AISkill, new Vector3(-5, 0, 0), Quaternion.identity);
        EventManager.Instance.ShackScreen(0.1f, 1f);

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }
}