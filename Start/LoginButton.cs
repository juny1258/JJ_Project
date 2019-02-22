using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using UnityEngine;

public class LoginButton : MonoBehaviour {

    public void Login()
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
}
