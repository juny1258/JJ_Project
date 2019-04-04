using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill1Upgrade : MonoBehaviour
{

	public Text TitleText;
	public Text InfoText;
	public Text CostText;

	private int startSkillCost = 20;

	private int cost;
	
	private void OnEnable()
	{
		cost = startSkillCost * (DataController.Instance.skill_1 + 1);
		
		UpdateUI();
	}

	public void UpgradeSkill()
	{
		if (DataController.Instance.skill_1 < 25)
		{
			if (DataController.Instance.sapphire >= cost)
			{
				DataController.Instance.sapphire -= cost;

				if (DataController.Instance.skill_1 == 0)
				{
					if (Social.localUser.authenticated)
					{
						Social.ReportProgress(GPGSIds.achievement_purchase_skill, 100f, isSuccess => { });
					}
				}
				
				DataController.Instance.skill_1++;
				DataController.Instance.skill_1_damage += 0.1f;
			
				print(DataController.Instance.skill_1);
			
				cost = startSkillCost * (DataController.Instance.skill_1 + 1);

				UpdateUI();
				// 스킬 업그레이드 됨
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
			if (DataController.Instance.skill_1 < 25)
			{
				TitleText.text = "박쥐 소환[+" + DataController.Instance.skill_1 + "]";
				InfoText.text = "공격력의 " + Math.Round(DataController.Instance.skill_1_damage * 100, 0) + "%로 10번 공격";
				CostText.text = cost.ToString();
			}
			else
			{
				TitleText.text = "박쥐 소환[+" + DataController.Instance.skill_1 + "]";
				InfoText.text = "공격력의 " + Math.Round(DataController.Instance.skill_1_damage * 100, 0) + "%로 10번 공격";
				CostText.text = "MAX";
			}	
		}
		else if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			if (DataController.Instance.skill_1 < 25)
			{
				TitleText.text = "バット召喚[+" + DataController.Instance.skill_1 + "]";
				InfoText.text = "攻撃力の " + Math.Round(DataController.Instance.skill_1_damage * 100, 0) + "%で10回攻撃";
				CostText.text = cost.ToString();
			}
			else
			{
				TitleText.text = "バット召喚[+" + DataController.Instance.skill_1 + "]";
				InfoText.text = "攻撃力の " + Math.Round(DataController.Instance.skill_1_damage * 100, 0) + "%で10回攻撃";
				CostText.text = "MAX";
			}	
		}
		else
		{
			if (DataController.Instance.skill_1 < 25)
			{
				TitleText.text = "Bat[+" + DataController.Instance.skill_1 + "]";
				InfoText.text = "10 attacks\n with " + Math.Round(DataController.Instance.skill_1_damage * 100, 0) + "% of damage";
				CostText.text = cost.ToString();
			}
			else
			{
				TitleText.text = "Bat[+" + DataController.Instance.skill_1 + "]";
				InfoText.text = "10 attacks\n with " + Math.Round(DataController.Instance.skill_1_damage * 100, 0) + "% of damage";
				CostText.text = "MAX";
			}	
		}
	}
}
