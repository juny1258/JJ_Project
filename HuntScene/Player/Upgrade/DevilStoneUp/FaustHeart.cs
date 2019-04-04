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
			if (DataController.Instance.devilStone >= 5000)
			{
				DataController.Instance.devilStone -= 5000;

				DataController.Instance.legendDevilStone = 1;
				
				DataController.Instance.UpdateDamage();
				DataController.Instance.UpdateCritical();
			
				UpdateUI();
			}
			else
			{
				NotificationManager.Instance.SetNotification(LocalManager.Instance.LessDevilstone);
			}	
		}
	}

	private void UpdateUI()
	{
		if (Application.systemLanguage == SystemLanguage.Korean)
		{
			if (DataController.Instance.legendDevilStone == 0)
			{
				InfoText.text = "초월레벨 비례 공격력 증가\n0% -> " + DataController.Instance.rebirthLevel +
				                " x 300 = " + DataController.Instance.rebirthLevel * 300 + "%";
				UpgradeInfo.text = "구매하기";
			}
			else
			{
				InfoText.text = "초월레벨 비례 공격력 증가\n" + DataController.Instance.rebirthLevel +
				                " x 300 = " + DataController.Instance.rebirthLevel * 300 + "%";
				UpgradeInfo.text = "구매완료";
			}	
		}
		if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			if (DataController.Instance.legendDevilStone == 0)
			{
				InfoText.text = "超越レベル比例攻撃力増加\n0% -> " + DataController.Instance.rebirthLevel +
				                " x 300 = " + DataController.Instance.rebirthLevel * 300 + "%";
				UpgradeInfo.text = "購入";
			}
			else
			{
				InfoText.text = "超越レベル比例攻撃力増加\n" + DataController.Instance.rebirthLevel +
				                " x 300 = " + DataController.Instance.rebirthLevel * 300 + "%";
				UpgradeInfo.text = "購入完了";
			}	
		}
		else
		{
			if (DataController.Instance.legendDevilStone == 0)
			{
				InfoText.text = "Rising Damage Per Level\n0% -> " + DataController.Instance.rebirthLevel +
				                " x 300 = " + DataController.Instance.rebirthLevel * 300 + "%";
				UpgradeInfo.text = "Buy";
			}
			else
			{
				InfoText.text = "Rising Damage Per Level\n" + DataController.Instance.rebirthLevel +
				                " x 300 = " + DataController.Instance.rebirthLevel * 300 + "%";
				UpgradeInfo.text = "Purchased";
			}	
		}
	}
}
