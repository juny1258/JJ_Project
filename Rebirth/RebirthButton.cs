﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebirthButton : MonoBehaviour
{
    public GameObject RebirthPanel;
    public GameObject ClickText;

    public void OpenMenu()
    {
        if (!DataController.Instance.isFight)
        {
            // 레벨 조정 20
            if (DataController.Instance.nowRebirthLevel < 19)
            {
                if (DataController.Instance.rebirthLevel - DataController.Instance.nowRebirthLevel > 0)
                {
                    ClickText.SetActive(false);
                    RebirthPanel.SetActive(true);
                }
                else
                {
                    NotificationManager.Instance.SetNotification("아직 초월할 수 없습니다.");
                }      
            }
            else
            {
                NotificationManager.Instance.SetNotification("최고 레벨입니다.");
            }
        }
    }
}