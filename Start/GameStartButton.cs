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
    
    private DatabaseReference userReference;

    private void Start()
    {
//        userReference = FirebaseManager.Instance.Reference.Child("userData");
    }

    public void StartButton()
    {
//        if (StartGame.isHack == 1)
//        {
//
//        print(1);
//        
//        userReference.Child("107392276203389471463").GetValueAsync().ContinueWith(task =>
//        {
//            if (task.IsCompleted)
//            {
//                foreach (var child in task.Result.Children)
//                {
//                    var userData = JsonUtility.FromJson<UserRankData>(child.GetRawJsonValue());
//                    print(userData.userName);
//                    if (userData.userName == "노가다게임조으당")
//                    {
//                        print("Key : " + child.Key);
//                        break;
//                    }
//                }
//            }
//            else
//            {
//                print(12);
//            }
//        });
//        
//        print(2);

        if (Debug.isDebugBuild)
        {
            if (!Social.localUser.authenticated)
            {
                PlayerPrefs.SetFloat("StartGame", 0);
                LoadingPanel.SetActive(true);
            }
            else
            {
                if (Application.systemLanguage == SystemLanguage.Korean)
                {
                    NotificationManager.Instance.SetNotification("로그인 후 이용해주세요.");
                }
                else if (Application.systemLanguage == SystemLanguage.Japanese)
                {
                    NotificationManager.Instance.SetNotification("ログイン後利用ください。");
                }
                else
                {
                    NotificationManager.Instance.SetNotification("Please use it after Login.");
                }

                LoginButton.SetActive(true);
            }   
        }
        else
        {
            if (Social.localUser.authenticated)
            {
                PlayerPrefs.SetFloat("StartGame", 0);
                LoadingPanel.SetActive(true);
            }
            else
            {
                if (Application.systemLanguage == SystemLanguage.Korean)
                {
                    NotificationManager.Instance.SetNotification("로그인 후 이용해주세요.");
                }
                else if (Application.systemLanguage == SystemLanguage.Japanese)
                {
                    NotificationManager.Instance.SetNotification("ログイン後利用ください。");
                }
                else
                {
                    NotificationManager.Instance.SetNotification("Please use it after Login.");
                }

                LoginButton.SetActive(true);
            }
        }
        

//        }
//        else
//        {
//            NotificationManager.Instance.SetNotification("로그인중입니다.");
//        }
    }
}