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

			Social.ReportScore((long) highScore, GPGSIds.leaderboard_3, success =>
			{
				if (success)
				{
					print("Success");
				}
			});
			
			Social.ReportScore((long) DataController.Instance.monsterKillCount, GPGSIds.leaderboard_4, success =>
			{
				if (success)
				{
					print("Success");
				}
			});
			
			Social.ReportScore((long) DataController.Instance.masterCriticalDamage, GPGSIds.leaderboard_2, success =>
			{
				if (success)
				{
					print("Success");
				}
			});
		}
        
        
	}
}
