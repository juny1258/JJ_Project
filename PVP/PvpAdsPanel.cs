using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpAdsPanel : MonoBehaviour
{

	public GameObject Panel;

	private void OnEnable()
	{
		EventManager.PvpAdsEvent += CompleteAds;
	}

	private void OnDisable()
	{
		EventManager.PvpAdsEvent -= CompleteAds;
	}

	private void CompleteAds()
	{
		Panel.SetActive(false);
	}

	public void OnAdsClick()
	{
		PlayerPrefs.SetFloat("AdIndex", 3);
		AdMob.Instance.ShowDungeonAd();
	}

	public void OnCloseButton()
	{
		Panel.SetActive(false);
	}
}
