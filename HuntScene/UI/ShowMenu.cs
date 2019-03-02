using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{

	public GameObject Panel;

	public void OpenPanel()
	{
		if (!DataController.Instance.isFight)
		{
			Panel.SetActive(true);	
		}
		else
		{
			NotificationManager.Instance.SetNotification("사냥중에는 메뉴를 열 수 없습니다.");
		}
	}
}
