using System;
using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {
	
	private DatabaseReference userReference;

	public GameObject UpdatePanel;
//
//	public static int isHack;
//
//	public GameObject BanPanel;

	public GameObject QuitPanel;

	// Use this for initialization
	void Start () {
		userReference = FirebaseManager.Instance.Reference.Child("Version");
		
		if (Application.systemLanguage == SystemLanguage.Japanese)
		{
			var textComponents = FindObjectsOfTypeAll(typeof(Text)) as Text[];
			foreach (var textComponent in textComponents)
			{
				textComponent.font = Resources.Load<Font>("Font/Japan3");
			}
		}
//
//		isHack = 0;
//		
		userReference.GetValueAsync().ContinueWith(task =>
		{
			if (task.IsCompleted)
			{
				var bundleVersion = int.Parse(task.Result.Value.ToString());

				// 256 == 257
				if (!(270 >= bundleVersion))
				{
					UpdatePanel.SetActive(true);
				}
			}
		});
		
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate(isSuccess =>
		{
			if (!isSuccess)
			{
				if (Application.systemLanguage == SystemLanguage.Korean)
				{
					NotificationManager.Instance.SetNotification("구글 플레이 게임 서비스 로그인 실패");
				}
				else if (Application.systemLanguage == SystemLanguage.Japanese)
				{
					NotificationManager.Instance.SetNotification("Googleのプレイゲームサービスのログインに失敗し");
				}
				else
				{
					NotificationManager.Instance.SetNotification("Login Fail on google play game service");
				}
			}
		});
		
		if (PlayerPrefs.GetFloat("Sound", 0) == 1)
		{
			AudioListener.volume = 0f;
		}
		else if (PlayerPrefs.GetFloat("Sound", 0) == 0)
		{
			AudioListener.volume = 1f;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			QuitPanel.SetActive(true);
		}
	}
}
