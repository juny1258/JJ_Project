using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenAutoPanel : MonoBehaviour
{
	// 비활성화 시 레벨, 활성화 시 시간 표시
	public Text LevelText;
	
	public GameObject AutoClick1;
	public GameObject AutoClick2;

	private void Start()
	{
		DataController.Instance.autoClickPotion = 0;
	}

	public void OnClick()
	{
		if (!DataController.Instance.useAutoClick)
		{
			if (DataController.Instance.autoClickPotion > 0)
			{
				// 물약이 있을 때
				AutoClick2.SetActive(true);		
			}
			else
			{
				AutoClick1.SetActive(true);
			}
		}
		else
		{
			NotificationManager.Instance.SetNotification("이미 사용중입니다.");
		}
	}

	private void Update()
	{
		if (DataController.Instance.useAutoClick && !DataController.Instance.isMenuOpen)
		{
			DataController.Instance.autoClickTime -= Time.deltaTime;
			var min = (int)DataController.Instance.autoClickTime / 60;
			var sec = (int) DataController.Instance.autoClickTime - 60 * min;
			LevelText.text = string.Format("{0:00}:{1:00}", min, sec);
		}
		else
		{
			LevelText.text = "Lv. " + (DataController.Instance.autoClickLevel+1);
		}
	}
}
