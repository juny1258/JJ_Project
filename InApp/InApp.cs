using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InApp : MonoBehaviour
{

    public void PurchaseRubyItem(int i)
    {
        switch (i)
        {
            case 0:
                DataController.Instance.ruby += 400;
                NotificationManager.Instance.SetNotification2("루비 400개 획득!!");
                break;
            case 1:
                DataController.Instance.ruby += 2400;
                NotificationManager.Instance.SetNotification2("루비 2,400개 획득!!");
                break;
            case 2:
                DataController.Instance.ruby += 5000;
                NotificationManager.Instance.SetNotification2("루비 5,000개 획득!!");
                break;
            case 3:
                DataController.Instance.ruby += 28000;
                NotificationManager.Instance.SetNotification2("루비 28,000개 획득!!");
                break;
            case 4:
                DataController.Instance.ruby += 60000;
                NotificationManager.Instance.SetNotification2("루비 60,000개 획득!!");
                break;
        }
    }
    
    public void PurchaseSapphireItem(int i)
    {
        switch (i)
        {
            case 0:
                DataController.Instance.sapphire += 200;
                NotificationManager.Instance.SetNotification2("사파이어 200개 획득!!");
                break;
            case 1:
                DataController.Instance.sapphire += 1200;
                NotificationManager.Instance.SetNotification2("사파이어 1,200개 획득!!");
                break;
            case 2:
                DataController.Instance.sapphire += 2500;
                NotificationManager.Instance.SetNotification2("사파이어 2,500개 획득!!");
                break;
            case 3:
                DataController.Instance.sapphire += 14000;
                NotificationManager.Instance.SetNotification2("사파이어 14,000개 획득!!");
                break;
            case 4:
                DataController.Instance.sapphire += 30000;
                NotificationManager.Instance.SetNotification2("사파이어 30,000개 획득!!");
                break;
        }
    }

    public void PurchaseSkipCoupon(int i)
    {
        switch (i)
        {
            case 0:
                DataController.Instance.skipCoupon += 5;
                NotificationManager.Instance.SetNotification2("소탕권 5개 획득!!");
                break;
            case 1:
                DataController.Instance.skipCoupon += 30;
                NotificationManager.Instance.SetNotification2("소탕권 30개 획득!!");
                break;
            case 2:
                DataController.Instance.skipCoupon += 65;
                NotificationManager.Instance.SetNotification2("소탕권 65개 획득!!");
                break;
            case 3:
                DataController.Instance.skipCoupon += 350;
                NotificationManager.Instance.SetNotification2("소탕권 350개 획득!!");
                break;
        }
    }
}