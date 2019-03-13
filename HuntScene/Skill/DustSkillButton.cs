using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DustSkillButton : MonoBehaviour
{

	public GameObject DustSkillObject;
	
	public GameObject NotPurchasePanel;
	public Text TimeText;

	private void Start()
	{
		NotPurchasePanel.SetActive(DataController.Instance.skill_4 == 0);
		
		EventManager.UpgradeSkillEvent += UpSkill;
	}

	private void UpSkill()
	{
		NotPurchasePanel.SetActive(DataController.Instance.skill_4 == 0);
	}

	private void OnDestroy()
	{
		EventManager.UpgradeSkillEvent -= UpSkill;
	}

	public void PlaySkill()
	{
		if (DataController.Instance.skill_4_cooltime <= 0)
		{
			Instantiate(DustSkillObject, new Vector3(0, 0, 0), Quaternion.identity);
			EventManager.Instance.ShackScreen(0.1f, 1f);
			DataController.Instance.skill_4_cooltime = 60 - 3 * (DataController.Instance.collectionCoolTime / 5);
			EventManager.Instance.PlaySkill();
		}
	}
	
	private void Update()
	{
		if (DataController.Instance.skill_4_cooltime > 0)
		{
			TimeText.gameObject.SetActive(true);
			DataController.Instance.skill_4_cooltime -= Time.deltaTime;
			var min = (int)DataController.Instance.skill_4_cooltime / 60;
			var sec = (int) DataController.Instance.skill_4_cooltime - 60 * min;
			TimeText.text = string.Format("{0:00}:{1:00}", min, sec);
		}
		else
		{
			TimeText.gameObject.SetActive(false);
		}
	}
}
