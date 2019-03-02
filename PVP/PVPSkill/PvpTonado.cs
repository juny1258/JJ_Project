using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpTonado : MonoBehaviour
{
    public GameObject Panel;

    public GameObject PlayerSkill;

    public GameObject SkillEffect;

    private bool isClick;
    private float skillTime;

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
        Instantiate(PlayerSkill, new Vector3(0, -0.65f, 0), Quaternion.identity);
        EventManager.Instance.UseSkill(4);

        DataController.Instance.PlayerData.skillClickTime = skillTime;

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }

    private void PlayAISkill()
    {
        isClick = true;
        Instantiate(PlayerSkill, new Vector3(-5, -0.65f, 0), Quaternion.identity);
        EventManager.Instance.UseSkill(1);

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }
}