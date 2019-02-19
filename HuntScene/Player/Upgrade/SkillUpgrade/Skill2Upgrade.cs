using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill2Upgrade : MonoBehaviour
{
    public Text TitleText;
    public Text InfoText;
    public Text CostText;

    public GameObject NotPurchasePanel;

    private int startSkillCost = 30;

    private int cost;

    private void OnEnable()
    {
        cost = startSkillCost * (DataController.Instance.skill_2 + 1);

        UpdateUI();

        ViewNotPurchasePanel();

        EventManager.UpgradeSkillEvent += ViewNotPurchasePanel;
    }

    public void UpgradeSkill()
    {
        if (DataController.Instance.skill_2 < 20)
        {
            if (DataController.Instance.sapphire >= cost)
            {
                DataController.Instance.sapphire -= cost;

                DataController.Instance.skill_2++;
                DataController.Instance.skill_2_damage += 0.12f;

                print(DataController.Instance.skill_2);

                cost = startSkillCost * (DataController.Instance.skill_2 + 1);

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
        if (DataController.Instance.skill_2 < 20)
        {
            TitleText.text = "토네이도[+" + DataController.Instance.skill_2 + "]";
            InfoText.text = "공격력의 " + Math.Round(DataController.Instance.skill_2_damage * 100, 0) + "%로 10번 공격";
            CostText.text = cost.ToString();
        }
        else
        {
            TitleText.text = "토네이도[+" + DataController.Instance.skill_2 + "]";
            InfoText.text = "공격력의 " + Math.Round(DataController.Instance.skill_2_damage * 100, 0) + "%로 10번 공격";
            CostText.text = "MAX";
        }
    }

    private void ViewNotPurchasePanel()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_1 < 3);
    }
}