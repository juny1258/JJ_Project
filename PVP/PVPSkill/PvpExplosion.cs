using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PvpExplosion : MonoBehaviour
{
    public GameObject Panel;

    public GameObject Meteor;
    public GameObject Meteor1;
    public GameObject SkillObject;

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
        if (!isClick)
        {
            isClick = true;
            Panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Instantiate(SkillEffect, transform.position, Quaternion.identity);
            Instantiate(Meteor, new Vector3(-20f, 20f, 0), Quaternion.Euler(0, 0, -135));
            Invoke("DelaySkill", 0.6f);
            EventManager.Instance.PlaySkillSound();

            DataController.Instance.PlayerData.skillClickTime = skillTime;
        }
    }

    private void PlayAISkill()
    {
        if (!isClick)
        {
            isClick = true;
            Panel.GetComponent<Image>().color = new Color(0, 0, 0, 0);
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
            Instantiate(SkillEffect, transform.position, Quaternion.identity);
            Instantiate(Meteor1, new Vector3(15f, 20f, 0), Quaternion.Euler(0, 0, 135));
            Invoke("DelaySkill1", 0.6f);
            EventManager.Instance.PlaySkillSound();
        }
    }

    private void DelaySkill()
    {
        Instantiate(SkillObject, new Vector3(4f, -3f, 0), Quaternion.Euler(75, 0, 0));
        EventManager.Instance.UseSkill(5);
        EventManager.Instance.ShackScreen(0.15f, 1f);

        Destroy(Panel);
    }

    private void DelaySkill1()
    {
        Instantiate(SkillObject, new Vector3(-4f, -3f, 0), Quaternion.Euler(75, 0, 0));
        EventManager.Instance.UseSkill(2);
        EventManager.Instance.ShackScreen(0.15f, 1f);

        Destroy(Panel);
    }
}