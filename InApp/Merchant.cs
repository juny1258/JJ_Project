using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour {

	public GameObject Panel;
	
	private void OnEnable()
	{
		
		if (PlayerPrefs.GetFloat("Merchant", 0) == 1)
		{
			Panel.SetActive(false);
		}
	}

	public void GoMerchant()
	{
		Application.OpenURL("market://details?id=com.juny.merchant");
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			// 나갔을 때
		}
		else
		{
			// 다시 들어왔을 때
			if (PlayerPrefs.GetFloat("Merchant", 0) == 0)
			{
				if (AndroidUtil.IsAppInstalled("com.juny.merchant"))
				{
					PlayerPrefs.SetFloat("Merchant", 1);
					DataController.Instance.ruby += 2000;
					NotificationManager.Instance.SetNotification2("루비 2,000개가 지급되었습니다.");
					Panel.SetActive(false);
				}
			}
		}
	}
}
