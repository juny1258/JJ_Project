using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPakage : MonoBehaviour
{

	public GameObject Panel1;
	public GameObject Panel;
	
	private void OnEnable()
	{
		Panel.SetActive(PlayerPrefs.GetFloat("NoAds", 0) == 1);
		
		if (PlayerPrefs.GetFloat("NoAds", 0) == 1)
		{
			Panel1.SetActive(false);
		}
	}

	public void PurchasdStartPakage()
	{
		DataController.Instance.ruby += 4000;
		DataController.Instance.sapphire += 2000;
		DataController.Instance.devilStone += 2000;
        
		PlayerPrefs.SetFloat("NoAds", 1);
        
		NotificationManager.Instance.SetNotification2("스타터 패키지 구매완료!!");
		
		DataController.Instance.inAppPurchase += 15000;
		
		Panel.SetActive(PlayerPrefs.GetFloat("NoAds", 0) == 1);
	}
}
