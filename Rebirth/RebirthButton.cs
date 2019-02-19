﻿using System.Collections;
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
            if (DataController.Instance.rebirthLevel > 0)
            {
                RebirthPanel.SetActive(true);
            }
            else
            {
                NotificationManager.Instance.SetNotification("아직 환생할 수 없습니다.");
            }   
        }
    }
}