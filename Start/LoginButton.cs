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
                    NotificationManager.Instance.SetNotification("구글 플레이 게임 서비스 로그인 실패");
                }
            });   
        }
        else
        {
            NotificationManager.Instance.SetNotification2("로그인 성공!!");
        }
    }

    public void UpdateButton()
    {
        Application.OpenURL("market://details?id=com.Juny.Devil");
    }
}
