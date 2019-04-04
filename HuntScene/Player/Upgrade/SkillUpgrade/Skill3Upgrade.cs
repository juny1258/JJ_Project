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
    
    private void OnDestroy()
    {
        EventManager.UpgradeSkillEvent -= ViewNotPurchasePanel;
    }

    public void UpgradeSkill()
    {
        if (DataController.Instance.skill_3 < 25)
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
            if (DataController.Instance.skill_3 < 25)
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
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            if (DataController.Instance.skill_3 < 25)
            {
                TitleText.text = "影分身の術[+" + DataController.Instance.skill_3 + "]";
                InfoText.text = "影分身の術が " + Math.Round(DataController.Instance.skill_3_time, 1) + "秒持続";
                CostText.text = cost.ToString();
            }
            else
            {
                TitleText.text = "影分身の術[+" + DataController.Instance.skill_3 + "]";
                InfoText.text = "影分身の術が " + Math.Round(DataController.Instance.skill_3_time, 1) + "秒持続";
                CostText.text = "MAX";
            }
        }
        else
        {
            if (DataController.Instance.skill_3 < 25)
            {
                TitleText.text = "Shadow Partner[+" + DataController.Instance.skill_3 + "]";
                InfoText.text = "Shadow Partner\nlasts for " + Math.Round(DataController.Instance.skill_3_time, 1) + " seconds";
                CostText.text = cost.ToString();
            }
            else
            {
                TitleText.text = "Shadow Partner[+" + DataController.Instance.skill_3 + "]";
                InfoText.text = "Shadow Partner\nlasts for " + Math.Round(DataController.Instance.skill_3_time, 1) + " seconds";
                CostText.text = "MAX";
            }
        }
    }

    private void ViewNotPurchasePanel()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_2 < 1);
    }
}