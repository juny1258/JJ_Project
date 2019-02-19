using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaustHeart : MonoBehaviour
{

	public GameObject DevilStoneImage;
	public GameObject PriceText;
	public Text UpgradeInfo;

	public GameObject NowDamageText;
	public GameObject PurchaseCompleteText;
	
	private void OnEnable()
	{
		
	}

	private void UpdateUI()
	{
		if (DataController.Instance.legendDevilStone == 0)
		{
			DevilStoneImage.SetActive(true);
			PriceText.SetActive(true);
			NowDamageText.SetActive(false);
			PurchaseCompleteText.SetActive(false);
			UpgradeInfo.text = "구매하기";
		}
		else
		{
			DevilStoneImage.SetActive(false);
			PriceText.SetActive(false);
			NowDamageText.SetActive(true);
			PurchaseCompleteText.SetActive(true);
			UpgradeInfo.text = "구매완료";
		}
	}
}
