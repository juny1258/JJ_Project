using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill5Upgrade : MonoBehaviour
{
    public Text TitleText;
    public Text InfoText;
    public Text CostText;

    public GameObject NotPurchasePanel;

    private int startSkillCost = 60;

    private int cost;

    private void OnEnable()
    {
        cost = startSkillCost * (DataController.Instance.skill_5 + 1);

        UpdateUI();
        ViewNotPurchasePanel();

        EventManager.UpgradeSkillEvent += ViewNotPurchasePanel;
    }

    public void UpgradeSkill()
    {
        if (DataController.Instance.skill_5 < 20)
        {
            if (DataController.Instance.sapphire >= cost)
            {
                DataController.Instance.sapphire -= cost;

                DataController.Instance.skill_5++;
                DataController.Instance.skill_5_damage += 0.2f;

                cost = startSkillCost * (DataController.Instance.skill_5 + 1);

                UpdateUI();
                EventManager.Instance.UpgradeSkill();
            }
            else
            {
                NotificationManager.Instance.SetNotification("사파이어가 부족합니다.");
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification("더 이상 업그레이드 할 수 없습니다.");
        }
    }

    private void UpdateUI()
    {
        if (DataController.Instance.skill_5 < 20)
        {
            TitleText.text = "메테오[+" + DataController.Instance.skill_5 + "]";
            InfoText.text = "공격력의 " + Math.Round(DataController.Instance.skill_5_damage * 100, 0) + "%로 10번 공격";
            CostText.text = cost.ToString();
        }
        else
        {
            TitleText.text = "메테오[+" + DataController.Instance.skill_5 + "]";
            InfoText.text = "공격력의 " + Math.Round(DataController.Instance.skill_5_damage * 100, 0) + "%로 10번 공격";
            CostText.text = "MAX";
        }
    }

    private void ViewNotPurchasePanel()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_4 < 5);
    }
}