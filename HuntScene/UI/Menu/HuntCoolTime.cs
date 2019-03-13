using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuntCoolTime : MonoBehaviour
{
	public Text CouponTimer;

	private void OnEnable()
	{
		DataController.Instance.couponTime -= DataController.Instance.skipCool;
		
		if (DataController.Instance.skipCoupon < 3)
		{
			
			if (DataController.Instance.couponTime <= 0)
			{
				DataController.Instance.couponTime = 1800;
				DataController.Instance.skipCoupon++;
			}
			
			CouponTimer.gameObject.SetActive(true);
			var m = (int) DataController.Instance.couponTime / 60;
			var s = (int) DataController.Instance.couponTime - 60 * m;

			CouponTimer.text = string.Format("{0:00}:{1:00}", m, s);
		}
		else
		{
			CouponTimer.gameObject.SetActive(false);
		}
		
		InvokeRepeating("CoolTime", 1, 1);
	}

	private void CoolTime()
	{
		if (DataController.Instance.skipCoupon < 3)
		{
			DataController.Instance.couponTime -= 1;
			
			if (DataController.Instance.couponTime <= 0)
			{
				DataController.Instance.couponTime = 1800;
				DataController.Instance.skipCoupon++;
			}
			
			CouponTimer.gameObject.SetActive(true);
			var m = (int) DataController.Instance.couponTime / 60;
			var s = (int) DataController.Instance.couponTime - 60 * m;

			CouponTimer.text = string.Format("{0:00}:{1:00}", m, s);	
		}
		else
		{
			CouponTimer.gameObject.SetActive(false);
		}
	}
	
	private void OnDisable()
	{
		DataController.Instance.skipCool = 0;
		CancelInvoke();
	}
}
