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
    
    private void OnDestroy()
    {
        EventManager.UpgradeSkillEvent -= ViewNotPurchasePanel;
    }

    public void UpgradeSkill()
    {
        if (DataController.Instance.skill_6 < 25)
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
                NotificationManager.Instance.SetNotification(LocalManager.Instance.LessSapphire);
            }
        }
        else
        {
            NotificationManager.Instance.SetNotification(LocalManager.Instance.NoUpgrade);
        }
    }

    private void UpdateUI()
    {
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            if (DataController.Instance.skill_6 < 25)
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
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            if (DataController.Instance.skill_6 < 25)
            {
                TitleText.text = "大爆発[+" + DataController.Instance.skill_6 + "]";
                InfoText.text = "攻撃力の " + Math.Round(DataController.Instance.skill_6_damage * 100, 0) + "%で10回攻撃";
                CostText.text = cost.ToString();
            }
            else
            {
                TitleText.text = "大爆発[+" + DataController.Instance.skill_6 + "]";
                InfoText.text = "攻撃力の " + Math.Round(DataController.Instance.skill_6_damage * 100, 0) + "%で10回攻撃";
                CostText.text = "MAX";
            }	
        }
        else
        {
            if (DataController.Instance.skill_6 < 25)
            {
                TitleText.text = "BigBang[+" + DataController.Instance.skill_6 + "]";
                InfoText.text = "16 attacks\n with " + Math.Round(DataController.Instance.skill_6_damage * 100, 0) + "% of damage";
                CostText.text = cost.ToString();
            }
            else
            {
                TitleText.text = "BigBang[+" + DataController.Instance.skill_6 + "]";
                InfoText.text = "16 attacks\n with " + Math.Round(DataController.Instance.skill_6_damage * 100, 0) + "% of damage";
                CostText.text = "MAX";
            }	
        }
    }

    private void ViewNotPurchasePanel()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_5 < 1);
    }
}