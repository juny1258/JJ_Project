using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
	public void OpenTab(int index)
	{
		if (DataController.Instance.isFight)
		{
			NotificationManager.Instance.SetNotification(LocalManager.Instance.NoMenu1);
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
			NotificationManager.Instance.SetNotification(LocalManager.Instance.NoMenu1);
		}
		else if (DataController.Instance.isStatus)
		{
			NotificationManager.Instance.SetNotification(LocalManager.Instance.NoMenu2);
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
