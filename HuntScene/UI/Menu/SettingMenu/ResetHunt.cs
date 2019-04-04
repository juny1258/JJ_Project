using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHunt : MonoBehaviour
{
    public void Reset()
    {
        DataController.Instance.finalHuntLevel = 0;
        DataController.Instance.finalBossLevel = 0;

        if (Application.systemLanguage == SystemLanguage.Korean)
        {
            NotificationManager.Instance.SetNotification2("사냥터 레벨 초기화 완료");   
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            NotificationManager.Instance.SetNotification2("狩り場レベルの初期化完了");   
        }
        else
        {
            NotificationManager.Instance.SetNotification2("Level of hunt is completely reset");   
        }
    }
}
