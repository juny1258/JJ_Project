using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DevilHp : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
	public Text ProductName;
	public Text PriceText;
	public Text UpgradeInfo;

	private float startCurrentCost = 10;

	// 업그레이드 후 데미지
	[HideInInspector] public float damageByUpgrade;

	private void Start()
	{
		UpdateUI();
	}

	private IEnumerator UpgradeCoroutine()
	{
		yield return new WaitForSeconds(0.5f);
		while (true)
		{
			UpgradeButtonClick();

			yield return new WaitForSeconds(0.02f);
		}
	}

	public void UpgradeButtonClick()
	{
		if (DataController.Instance.devilHpLevel <= 100)
		{
			if (DataController.Instance.devilStone >= startCurrentCost * DataController.Instance.devilHpLevel)
			{
				DataController.Instance.devilStone -= startCurrentCost * DataController.Instance.devilHpLevel;

				DataController.Instance.devilHp += 0.01f * DataController.Instance.devilHpLevel;

				DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();

				DataController.Instance.devilHpLevel++;

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
		if (DataController.Instance.devilHpLevel <= 100)
		{
			ProductName.text = LocalManager.Instance.Hp + "[+" + (DataController.Instance.devilHpLevel - 1) + "]";
			PriceText.text = Math.Round(startCurrentCost * DataController.Instance.devilHpLevel, 0).ToString();

			UpgradeInfo.text = Math.Round((DataController.Instance.devilHp - 1) * 100, 0) + "% -> " +
			                   Math.Round((DataController.Instance.devilHp - 1
			                               + 0.01f * DataController.Instance.devilHpLevel) * 100, 0) + "%";
		}
		else
		{
			ProductName.text = LocalManager.Instance.Hp + "[+" + (DataController.Instance.devilHpLevel - 1) + "]";
			PriceText.text = "MAX";

			UpgradeInfo.text = Math.Round((DataController.Instance.devilHp - 1) * 100, 0) + "%";
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		StopAllCoroutines();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		StartCoroutine("UpgradeCoroutine");
	}
}
