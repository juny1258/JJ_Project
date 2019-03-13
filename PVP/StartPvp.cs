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
            NotificationManager.Instance.SetNotification("로딩중... 잠시 후 시도하세요.");
        }
    }

    public void OnEndPvp()
    {
        NotificationManager.Instance.SetNotification("나가는 중");
        SceneManager.LoadScene(1);
    }
}