using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpBigBang : MonoBehaviour
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
        Instantiate(PlayerSkill, new Vector3(0, 0, 0), Quaternion.identity);
        EventManager.Instance.UseSkill(6);
        EventManager.Instance.ShackScreen(0.1f, 1.5f);
        EventManager.Instance.PlaySkillSound2();

        DataController.Instance.PlayerData.skillClickTime = skillTime;

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }

    private void PlayAISkill()
    {
        isClick = true;
        Instantiate(PlayerSkill, new Vector3(0, 0, 0), new Quaternion(0, 180, 0, 0));
        EventManager.Instance.UseSkill(3);
        EventManager.Instance.ShackScreen(0.1f, 1.5f);
        EventManager.Instance.PlaySkillSound2();

        Instantiate(SkillEffect, transform.position, Quaternion.identity);
        Destroy(Panel);
    }
}