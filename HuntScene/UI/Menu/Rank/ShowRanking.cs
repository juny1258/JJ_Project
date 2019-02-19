using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;

public class ShowRanking : MonoBehaviour {

	public void ShowBoard()
	{
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate(ShowLeaderBoard);
	}

	public void ShowAchieve()
	{
		PlayGamesPlatform.Activate();
		Social.localUser.Authenticate(ShowAchieveBoard);
	}
	
	
	private void ShowLeaderBoard(bool isSuccess, string ErrorMessage)
	{
		if (isSuccess)
		{	
			PlayGamesPlatform.Instance.ShowLeaderboardUI();
		}
		else
		{

			NotificationManager.Instance.SetNotification(ErrorMessage);
		}
	}
	
	private void ShowAchieveBoard(bool isSuccess, string ErrorMessage)
	{
		if (isSuccess)
		{	
			PlayGamesPlatform.Instance.ShowAchievementsUI();
		}
		else
		{

			NotificationManager.Instance.SetNotification(ErrorMessage);
		}
	}
}
