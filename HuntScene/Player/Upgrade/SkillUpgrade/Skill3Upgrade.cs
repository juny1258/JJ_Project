using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill3Upgrade : MonoBehaviour
{
    public Text TitleText;
    public Text InfoText;
    public Text CostText;

    public GameObject NotPurchasePanel;

    private int startSkillCost = 40;

    private int cost;

    private void OnEnable()
    {
        cost = startSkillCost * (DataController.Instance.skill_3 + 1);

        UpdateUI();
        ViewNotPurchasePanel();

        EventManager.UpgradeSkillEvent += ViewNotPurchasePanel;
    }

    public void UpgradeSkill()
    {
        if (DataController.Instance.skill_3 < 20)
        {
            if (DataController.Instance.sapphire >= cost)
            {
                DataController.Instance.sapphire -= cost;

                DataController.Instance.skill_3++;
                DataController.Instance.skill_3_time += 0.2f;

                print(DataController.Instance.skill_3);

                cost = startSkillCost * (DataController.Instance.skill_3 + 1);

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
        if (DataController.Instance.skill_3 < 20)
        {
            TitleText.text = "쉐도우 파트너[+" + DataController.Instance.skill_3 + "]";
            InfoText.text = "쉐도우 파트너가 " + Math.Round(DataController.Instance.skill_3_time, 1) + "초 지속";
            CostText.text = cost.ToString();
        }
        else
        {
            TitleText.text = "쉐도우 파트너[+" + DataController.Instance.skill_3 + "]";
            InfoText.text = "쉐도우 파트너가 " + Math.Round(DataController.Instance.skill_3_time, 1) + "초 지속";
            CostText.text = "MAX";
        }
    }

    private void ViewNotPurchasePanel()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_2 < 3);
    }
}