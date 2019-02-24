using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaustHeart : MonoBehaviour
{

	public Text UpgradeInfo;

	public Text InfoText;
	
	private void OnEnable()
	{
		UpdateUI();
	}

	public void PurchaseItem()
	{
		if (DataController.Instance.legendDevilStone == 0)
		{
			if (DataController.Instance.devilStone >= 10000)
			{
				DataController.Instance.devilStone -= 10000;

				DataController.Instance.legendDevilStone = 1;
				
				DataController.Instance.UpdateDamage();
				DataController.Instance.UpdateCritical();
			
				UpdateUI();
			}
			else
			{
				NotificationManager.Instance.SetNotification("데빌스톤이 부족합니다.");
			}	
		}
	}

	private void UpdateUI()
	{
		if (DataController.Instance.legendDevilStone == 0)
		{
			InfoText.text = "환생레벨 비례 공격력 증가\n0% -> " + DataController.Instance.rebirthLevel +
			                " x 300 = " + DataController.Instance.rebirthLevel * 300 + "%";
			UpgradeInfo.text = "구매하기";
		}
		else
		{
			InfoText.text = "환생레벨 비례 공격력 증가\n" + DataController.Instance.rebirthLevel +
			                " x 300 = " + DataController.Instance.rebirthLevel * 300 + "%";
			UpgradeInfo.text = "구매완료";
		}
	}
}
