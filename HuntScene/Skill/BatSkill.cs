using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatSkill : MonoBehaviour
{
    public GameObject BatSkillObject;
    public GameObject NotPurchasePanel;
    public Text TimeText;

    private void Start()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_1 == 0);
        
        EventManager.UpgradeSkillEvent += UpSkill;
    }

    private void UpSkill()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_1 == 0);
    }

    private void OnDestroy()
    {
        EventManager.UpgradeSkillEvent -= UpSkill;
    }

    public void PlaySkill()
    {
        if (DataController.Instance.skill_1_cooltime <= 0)
        {
            DataController.Instance.skill_1_cooltime = 180 - 9 * (DataController.Instance.collectionCoolTime / 5);
            Instantiate(BatSkillObject, new Vector3(-4.65f, -2.37f, 0), Quaternion.identity);
            EventManager.Instance.PlaySkill();
        }
    }

    private void Update()
    {
        if (DataController.Instance.skill_1_cooltime > 0)
        {
            TimeText.gameObject.SetActive(true);
            DataController.Instance.skill_1_cooltime -= Time.deltaTime;
            var min = (int)DataController.Instance.skill_1_cooltime / 60;
            var sec = (int) DataController.Instance.skill_1_cooltime - 60 * min;
            TimeText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            TimeText.gameObject.SetActive(false);
        }
    }
}