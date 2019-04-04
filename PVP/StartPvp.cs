using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPvp : MonoBehaviour
{
    public GameObject AdsMenu;

    public void OnStartPvp()
    {
        if (DataController.Instance.isPvpReady)
        {
            EventManager.Instance.StartPvp();
            DataController.Instance.isPvpReady = false;
        }
        else
        {
            if (Application.systemLanguage == SystemLanguage.Korean)
            {
                NotificationManager.Instance.SetNotification("로딩중... 잠시 후 시도하세요.");   
            }
            else if (Application.systemLanguage == SystemLanguage.Japanese)
            {
                NotificationManager.Instance.SetNotification("ロード中...しばらくしてお試しください。");   
            }
            else
            {
                NotificationManager.Instance.SetNotification("Loading... Please try in a moment.");   
            }
        }
    }

    public void OnEndPvp()
    {
        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            NotificationManager.Instance.SetNotification("나가는 중");
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            NotificationManager.Instance.SetNotification("いく中");   
        }
        else
        {
            NotificationManager.Instance.SetNotification("Please Wait");
        }
        SceneManager.LoadScene(1);
    }
}