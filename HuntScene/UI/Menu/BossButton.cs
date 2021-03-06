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

		if (DataController.Instance.finalBossLevel > index)
		{
			rubyText.text = "x" + global::BossSpwan.ruby[DataController.Instance.finalBossLevel - 1];
			sapphireText.text = "x" + global::BossSpwan.sapphire[DataController.Instance.finalBossLevel - 1];
		}
	}

	public void StartGame()
	{
		if (!DataController.Instance.isFight)
		{
			if (PlayerPrefs.GetFloat("BossCoolTime_" + index, 0) <= 0)
			{
				DataController.Instance.isFight = true;
				MoveSceneAnimator.Play("MoveScene", 0, 0);
				Invoke("StartHunt", 0.5f);
			}
			else
			{
				NotificationManager.Instance.SetNotification(LocalManager.Instance.NoEnter);
			}
		}
	}
	
	public void StartHunt()
	{
		DataController.Instance.bossLevel = index;
		RockObject.SetActive(false);
		BossSpwan.SetActive(true);
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
					if (DataController.Instance.skipCoupon >= 3)
					{
						DataController.Instance.couponTime = 1800;
					}
					
					DataController.Instance.skipCoupon -= 1;
					
					if (DataController.Instance.finalBossLevel == index)
					{
						RewardManager.Instance.ShowRewardPanel(
							global::BossSpwan.ruby[index], global::BossSpwan.sapphire[index]);
					}
					else
					{
						RewardManager.Instance.ShowRewardPanel(
							global::BossSpwan.ruby[DataController.Instance.finalBossLevel-1], global::BossSpwan.sapphire[DataController.Instance.finalBossLevel-1]);
					}
					
					PlayerPrefs.SetFloat("BossCoolTime_" + index, 300);
					NotClearPanel.SetActive(index > DataController.Instance.finalBossLevel);
				}
				else
				{
					NotificationManager.Instance.SetNotification(LocalManager.Instance.LessScroll);
				}		
			}
			else
			{
				NotificationManager.Instance.SetNotification(LocalManager.Instance.NoEnter);
			}
		}
		else
		{
			NotificationManager.Instance.SetNotification(LocalManager.Instance.AfterClear);
		}
	}
}
