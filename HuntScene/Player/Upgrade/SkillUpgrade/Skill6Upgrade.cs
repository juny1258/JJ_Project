using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill6Upgrade : MonoBehaviour
{
    public Text TitleText;
    public Text InfoText;
    public Text CostText;

    public GameObject NotPurchasePanel;

    private int startSkillCost = 70;

    private int cost;

    private void OnEnable()
    {
        cost = startSkillCost * (DataController.Instance.skill_6 + 1);

        UpdateUI();
        ViewNotPurchasePanel();

        EventManager.UpgradeSkillEvent += ViewNotPurchasePanel;
    }

    public void UpgradeSkill()
    {
        if (DataController.Instance.skill_6 < 20)
        {
            if (DataController.Instance.sapphire >= cost)
            {
                DataController.Instance.sapphire -= cost;

                DataController.Instance.skill_6++;
                DataController.Instance.skill_6_damage += 0.15f;

                print(DataController.Instance.skill_6);

                cost = startSkillCost * (DataController.Instance.skill_6 + 1);

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
        if (DataController.Instance.skill_6 < 20)
        {
            TitleText.text = "빅뱅[+" + DataController.Instance.skill_6 + "]";
            InfoText.text = "공격력의 " + Math.Round(DataController.Instance.skill_6_damage * 100, 0) + "%로 16번 공격";
            CostText.text = cost.ToString();
        }
        else
        {
            TitleText.text = "빅뱅[+" + DataController.Instance.skill_6 + "]";
            InfoText.text = "공격력의 " + Math.Round(DataController.Instance.skill_6_damage * 100, 0) + "%로 16번 공격";
            CostText.text = "MAX";
        }
    }

    private void ViewNotPurchasePanel()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_5 < 5);
    }
}