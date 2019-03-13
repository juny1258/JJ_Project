using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using UnityEngine;

public class StartGame : MonoBehaviour {
	
//	private DatabaseReference userReference;
//
//	public static int isHack;
//
//	public GameObject BanPanel;

	public GameObject QuitPanel;

	// Use this for initialization
	void Start () {
//		userReference = FirebaseManager.Instance.Reference.Child("FaustRank");
//
//		isHack = 0;
//		
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate(isSuccess =>
		{
			if (!isSuccess)
			{
				NotificationManager.Instance.SetNotification("구글 플레이 게임 서비스 로그인 실패");
			}
//			else
//			{
//				userReference.Child(PlayGamesPlatform.Instance.localUser.id).GetValueAsync().ContinueWith(
//					task =>
//					{
//						if (task.IsCompleted)
//						{
//							NotificationManager.Instance.SetNotification("1");
//							if (task.Result.Exists)
//							{
//								NotificationManager.Instance.SetNotification("2");
//								var userData = JsonUtility.FromJson<UserRankData>(task.Result.GetRawJsonValue());
//								if (userData.isHack == 0)
//								{
//									NotificationManager.Instance.SetNotification("3");
//									isHack = 1;
//								}
//								else
//								{
//									BanPanel.SetActive(true);
//								}
//							}
//							else
//							{
//								NotificationManager.Instance.SetNotification("4");
//								isHack = 1;
//							}
//						}
//						else
//						{
//							
//							NotificationManager.Instance.SetNotification("5");
//						}
//					});
//			}
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
