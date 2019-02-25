using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebirthButton : MonoBehaviour
{
    public GameObject RebirthPanel;

    public void OpenMenu()
    {
        if (!DataController.Instance.isFight)
        {
            if (DataController.Instance.rebirthLevel < 14)
            {
                if (DataController.Instance.rebirthLevel - DataController.Instance.nowRebirthLevel > 0)
                {
                    RebirthPanel.SetActive(true);
                }
                else
                {
                    NotificationManager.Instance.SetNotification("아직 환생할 수 없습니다.");
                }      
            }
            else
            {
                NotificationManager.Instance.SetNotification("최고 레벨입니다.");
            }
        }
    }
}