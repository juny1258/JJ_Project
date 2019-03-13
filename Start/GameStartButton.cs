using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{
    public GameObject LoadingPanel;
    public GameObject LoginButton;

    public void StartButton()
    {
//        if (StartGame.isHack == 1)
//        {
            if (Social.localUser.authenticated)
            {
                PlayerPrefs.SetFloat("StartGame", 0);
                LoadingPanel.SetActive(true);
            }
            else
            {
                NotificationManager.Instance.SetNotification("로그인 후 이용해주세요.");

                LoginButton.SetActive(true);
            }   
//        }
//        else
//        {
//            NotificationManager.Instance.SetNotification("로그인중입니다.");
//        }
    }
}