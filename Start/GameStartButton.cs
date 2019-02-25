﻿using System.Collections;
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
        if (Social.localUser.authenticated)
        {
            LoadingPanel.SetActive(true);

            SceneManager.LoadScene(1);
        }
        else
        {
            NotificationManager.Instance.SetNotification("로그인 후 이용해주세요.");

            LoginButton.SetActive(true);
        }
    }
}