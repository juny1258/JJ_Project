﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant2 : MonoBehaviour
{
    public GameObject Panel;
	
    private void OnEnable()
    {
		
        if (PlayerPrefs.GetFloat("Merchant2", 0) == 1)
        {
            Panel.SetActive(false);
        }
    }

    public void GoMerchant()
    {
        Application.OpenURL("market://details?id=com.pancol.LifeIsGood");
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // 나갔을 때
        }
        else
        {
            // 다시 들어왔을 때
            if (PlayerPrefs.GetFloat("Merchant2", 0) == 0)
            {
                if (AndroidUtil.IsAppInstalled("com.pancol.LifeIsGood"))
                {
                    PlayerPrefs.SetFloat("Merchant2", 1);
                    DataController.Instance.ruby += 1000;
                    if (Application.systemLanguage == SystemLanguage.Korean)
                    {
                        NotificationManager.Instance.SetNotification2("루비 1,000개가 지급되었습니다.");	
                    }
                    else
                    {
                        NotificationManager.Instance.SetNotification2("Get 1,000 Ruby!!");	
                    }
                    Panel.SetActive(false);
                }
            }
        }
    }
}
