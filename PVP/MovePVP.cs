using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePVP : MonoBehaviour {

	public void MoveScene()
	{
		if (DataController.Instance.isFight)
		{
			NotificationManager.Instance.SetNotification(LocalManager.Instance.NoMenu1);
		}
		else
		{
			if (Social.localUser.authenticated)
			{
				SceneManager.LoadScene(2);	
			}
			else
			{
				NotificationManager.Instance.SetNotification(LocalManager.Instance.Internet);
			}	
		}
	}
}
