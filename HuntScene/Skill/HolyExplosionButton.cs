﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolyExplosionButton : MonoBehaviour {

	public GameObject DustSkillObject;
	
	public GameObject NotPurchasePanel;

	public Text TimeText;

	private AudioSource SkillAudio;

	private void Start()
	{
		NotPurchasePanel.SetActive(DataController.Instance.skill_6 == 0);

		SkillAudio = GetComponent<AudioSource>();
		
		EventManager.UpgradeSkillEvent += () => { NotPurchasePanel.SetActive(DataController.Instance.skill_6 == 0); };
	}

	public void PlaySkill()
	{
		if (DataController.Instance.skill_6_cooltime <= 0)
		{
			SkillAudio.Play();
			Instantiate(DustSkillObject, new Vector3(0, 0, 0), Quaternion.identity);
			EventManager.Instance.UseSkill(4);
			EventManager.Instance.ShackScreen(0.1f, 1.5f);
			DataController.Instance.skill_6_cooltime = 180 - 9 * (DataController.Instance.collectionCoolTime / 5);
		}
	}
	
	private void Update()
	{
		if (DataController.Instance.skill_6_cooltime > 0)
		{
			TimeText.gameObject.SetActive(true);
			DataController.Instance.skill_6_cooltime -= Time.deltaTime;
			var min = (int)DataController.Instance.skill_6_cooltime / 60;
			var sec = (int) DataController.Instance.skill_6_cooltime - 60 * min;
			TimeText.text = string.Format("{0:00}:{1:00}", min, sec);
		}
		else
		{
			TimeText.gameObject.SetActive(false);
		}
	}
}