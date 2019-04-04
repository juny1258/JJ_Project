using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;

public class LoginButton : MonoBehaviour {

    public void Login()
    {
        if (!Social.localUser.authenticated)
        {
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
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                NotificationManager.Instance.SetNotification2("로그인 성공!!");
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                NotificationManager.Instance.SetNotification2("ログインに成功！");
            }
            else
            {
                NotificationManager.Instance.SetNotification2("Login Success");
            }
        }
    }

    public void UpdateButton()
    {
        Application.OpenURL("market://details?id=com.Juny.Devil");
    }
}
