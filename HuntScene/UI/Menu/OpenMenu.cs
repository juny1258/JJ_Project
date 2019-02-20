using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
	public void OpenTab(int index)
	{
		if (DataController.Instance.isFight)
		{
			NotificationManager.Instance.SetNotification("사냥중에는 메뉴를 열 수 없습니다.");
		}
		else
		{
			MenuManager.Instance.OpenTab(3, index);
		}
		
	}
	
	public void MenuOpen(int index)
	{
		if (DataController.Instance.isFight)
		{
			NotificationManager.Instance.SetNotification("사냥중에는 메뉴를 열 수 없습니다.");
		}
		else
		{
			MenuManager.Instance.Open(index);
		}
		
	}

	public void MoveTab(int index)
	{
		MenuManager.Instance.MoveTab(index);
	}

	public void MenuClose()
	{
		MenuManager.Instance.Close();
	}
}
