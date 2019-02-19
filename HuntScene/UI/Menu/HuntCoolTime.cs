using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntCoolTime : MonoBehaviour
{
	public GameObject[] HuntTimerPanels;
	public Text[] HuntTimerTexts;
	
	public GameObject[] BossTimerPanels;
	public Text[] BossTimerTexts;

	public Text CouponTimer;

	private void Start()
	{
		EventManager.RebirthEvent += ResetCoolTime;
	}

	// Update is called once per frame
	void Update () {
		for (var i = 0; i < HuntTimerPanels.Length; i++)
		{
			if (PlayerPrefs.GetFloat("HuntCoolTime_" + i, 0) > 0)
			{
				HuntTimerPanels[i].SetActive(true);
				var min = (int)PlayerPrefs.GetFloat("HuntCoolTime_" + i, 0) / 60;
				var sec = (int)PlayerPrefs.GetFloat("HuntCoolTime_" + i, 0) - 60 * min;
				HuntTimerTexts[i].text = string.Format("{0:00}:{1:00}", min, sec);
			}
			else
			{
				HuntTimerPanels[i].SetActive(false);
			}
		}
		
		for (var i = 0; i < BossTimerPanels.Length; i++)
		{
			if (PlayerPrefs.GetFloat("BossCoolTime_" + i, 0) > 0)
			{
				BossTimerPanels[i].SetActive(true);
				var min = (int)PlayerPrefs.GetFloat("BossCoolTime_" + i, 0) / 60;
				var sec = (int)PlayerPrefs.GetFloat("BossCoolTime_" + i, 0) - 60 * min;
				BossTimerTexts[i].text = string.Format("{0:00}:{1:00}", min, sec);
			}
			else
			{
				BossTimerPanels[i].SetActive(false);
			}
		}

		if (DataController.Instance.skipCoupon < 3)
		{
			CouponTimer.gameObject.SetActive(true);
			var m = (int) DataController.Instance.couponTime / 60;
			var s = (int) DataController.Instance.couponTime - 60 * m;
			
			print(DataController.Instance.couponTime);

			CouponTimer.text = string.Format("{0:00}:{1:00}", m, s);	
		}
		else
		{
			CouponTimer.gameObject.SetActive(false);
		}
	}

	private void ResetCoolTime()
	{
		for (var i = 0; i < HuntTimerPanels.Length; i++)
		{
			PlayerPrefs.SetFloat("HuntCoolTime_" + i, 0);
		}

		for (var i = 0; i < BossTimerPanels.Length; i++)
		{
			PlayerPrefs.SetFloat("BossCoolTime_" + i, 0);
		}

	}
}
