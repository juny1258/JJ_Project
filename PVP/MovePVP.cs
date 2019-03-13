using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePVP : MonoBehaviour {

	public void MoveScene()
	{
		if (Social.localUser.authenticated)
		{
			SceneManager.LoadScene(2);	
		}
		else
		{
			NotificationManager.Instance.SetNotification("인터넷 연결을 확인하세요.");
		}
	}
}
