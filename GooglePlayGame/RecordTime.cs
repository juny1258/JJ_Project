using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.UI;

public class RecordTime : MonoBehaviour {
	

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("RecordPlayTime", 30f, 30f);
	}

	private void RecordPlayTime()
	{
		if (Social.localUser.authenticated)
		{
			// login success
			PlayerPrefs.SetFloat("PlayTime", PlayerPrefs.GetFloat("PlayTime", 0) + 30000);
            
			float highScore = PlayerPrefs.GetFloat("PlayTime", 0);
			string leaderBoardId = "CgkI6PL7xdcQEAIQAg";

			Social.ReportScore((long) highScore, leaderBoardId, success =>
			{
				if (success)
				{
					print("Success");
				}
			});
			
			Social.ReportScore((long) DataController.Instance.monsterKillCount, GPGSIds.leaderboard_3, success =>
			{
				if (success)
				{
					print("Success");
				}
			});
			
			Social.ReportScore((long) DataController.Instance.masterCriticalDamage, GPGSIds.leaderboard_7, success =>
			{
				if (success)
				{
					print("Success");
				}
			});
		}
        
        
	}
}
