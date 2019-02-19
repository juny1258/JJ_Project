﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossButton : MonoBehaviour {

	public GameObject RockObject;
	public GameObject BossSpwan;

	public GameObject NotClearPanel;
	
	public Animator MoveSceneAnimator;
	
	public Text rubyText;
	public Text sapphireText;

	public int index;

	private void OnEnable()
	{
		NotClearPanel.SetActive(index > DataController.Instance.finalBossLevel);
		
		rubyText.text = "x" + global::BossSpwan.ruby[index];
		sapphireText.text = "x" + global::BossSpwan.sapphire[index];
	}
	
	public void StartGame()
	{
		if (PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) <= 0)
		{
			MoveSceneAnimator.Play("MoveScene", 0, 0);
			Invoke("StartHunt", 0.5f);
		}
		else
		{
			NotificationManager.Instance.SetNotification("지금은 입장할 수 없습니다.");
		}
	}
	
	public void StartHunt()
	{
		DataController.Instance.bossLevel = index;
		RockObject.SetActive(false);
		BossSpwan.SetActive(true);
		DataController.Instance.isFight = true;
		MenuManager.Instance.Close();
	}

	public void SkipHunt()
	{
		if (DataController.Instance.finalBossLevel > index)
		{
			if (PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) <= 0)
			{
				if (DataController.Instance.skipCoupon >= 1)
				{
					DataController.Instance.skipCoupon -= 1;
					RewardManager.Instance.ShowRewardPanel(
						(float) (global::BossSpwan.gold * Math.Pow(6f, index)),
						global::BossSpwan.ruby[index],
						global::BossSpwan.sapphire[index]);
					PlayerPrefs.SetFloat("BossCoolTime_" + index, 300);
					NotClearPanel.SetActive(index > DataController.Instance.finalBossLevel);
				}
				else
				{
					NotificationManager.Instance.SetNotification("소탕권이 부족합니다.");
				}		
			}
			else
			{
				NotificationManager.Instance.SetNotification("지금은 입장할 수 없습니다.");
			}
		}
		else
		{
			NotificationManager.Instance.SetNotification("클리어 후 소탕할 수 있습니다.");
		}
	}
}