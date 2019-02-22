using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate(isSuccess =>
		{
			if (!isSuccess)
			{
				NotificationManager.Instance.SetNotification("구글 플레이 게임 서비스 로그인 실패");
			}
		});
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}
