using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ReceiveFlyingReward : MonoBehaviour
{

	public GameObject FlyRewardPanel;

	public void OnReceive()
	{
		DataController.Instance.ruby += 3;
		FlyRewardPanel.SetActive(false);
		Time.timeScale = 1;
	}

	public void OnRewardButton()
	{
		ShowRewardedAd();
	}

	public void OnCloseButton()
	{
		FlyRewardPanel.SetActive(false);
		Time.timeScale = 1;
	}
	
	private void ShowRewardedAd()
	{
		if (PlayerPrefs.GetFloat("NoAds", 0) == 0)
		{
			// 광고 제거 전
			if (Advertisement.IsReady("rewardedVideo"))
			{
				var options = new ShowOptions {resultCallback = HandleShowResult};
				Advertisement.Show("rewardedVideo", options);   
			}
		}
		else
		{
			// 광고 제거 후
			DataController.Instance.ruby += 15;
			FlyRewardPanel.SetActive(false);
			Time.timeScale = 1;
		}
	}
	
	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				DataController.Instance.ruby += 15;
				FlyRewardPanel.SetActive(false);
				Time.timeScale = 1;

				//
				// YOUR CODE TO REWARD THE GAMER
				// Give coins etc.
				break;
			case ShowResult.Skipped:
				Debug.Log("The ad was skipped before reaching the end.");
				break;
			case ShowResult.Failed:
				Debug.LogError("The ad failed to be shown.");
				break;
		}
	}
}
