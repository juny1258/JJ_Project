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

                DataController.Instance.inAppPurchase += 1000;
                break;
            case 1:
                DataController.Instance.ruby += 2400;
                NotificationManager.Instance.SetNotification2("루비 2,400개 획득!!");
                
                DataController.Instance.inAppPurchase += 5000;
                break;
            case 2:
                DataController.Instance.ruby += 5000;
                NotificationManager.Instance.SetNotification2("루비 5,000개 획득!!");
                
                
                DataController.Instance.inAppPurchase += 10000;
                break;
            case 3:
                DataController.Instance.ruby += 28000;
                NotificationManager.Instance.SetNotification2("루비 28,000개 획득!!");
                
                
                DataController.Instance.inAppPurchase += 49000;
                break;
            case 4:
                DataController.Instance.ruby += 60000;
                NotificationManager.Instance.SetNotification2("루비 60,000개 획득!!");
                
                DataController.Instance.inAppPurchase += 99000;
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
                
                DataController.Instance.inAppPurchase += 1000;
                break;
            case 1:
                DataController.Instance.sapphire += 1200;
                NotificationManager.Instance.SetNotification2("사파이어 1,200개 획득!!");
                
                DataController.Instance.inAppPurchase += 5000;
                break;
            case 2:
                DataController.Instance.sapphire += 2500;
                NotificationManager.Instance.SetNotification2("사파이어 2,500개 획득!!");
                
                DataController.Instance.inAppPurchase += 10000;
                break;
            case 3:
                DataController.Instance.sapphire += 14000;
                NotificationManager.Instance.SetNotification2("사파이어 14,000개 획득!!");
                
                DataController.Instance.inAppPurchase += 49000;
                break;
            case 4:
                DataController.Instance.sapphire += 30000;
                NotificationManager.Instance.SetNotification2("사파이어 30,000개 획득!!");
                
                DataController.Instance.inAppPurchase += 99000;
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
                
                DataController.Instance.inAppPurchase += 1000;
                break;
            case 1:
                DataController.Instance.skipCoupon += 30;
                NotificationManager.Instance.SetNotification2("소탕권 30개 획득!!");
                
                DataController.Instance.inAppPurchase += 5000;
                break;
            case 2:
                DataController.Instance.skipCoupon += 65;
                NotificationManager.Instance.SetNotification2("소탕권 65개 획득!!");
                
                DataController.Instance.inAppPurchase += 10000;
                break;
            case 3:
                DataController.Instance.skipCoupon += 350;
                NotificationManager.Instance.SetNotification2("소탕권 350개 획득!!");
                
                DataController.Instance.inAppPurchase += 49000;
                break;
        }
    }
    
    public void PurchasePotion(int i)
    {
        switch (i)
        {
            case 0:
                if (DataController.Instance.ruby >= 800)
                {
                    DataController.Instance.ruby -= 800;
                    DataController.Instance.goldBuffPotion += 5;
                    NotificationManager.Instance.SetNotification2("결계 무력화 5개 획득!!");    
                }
                else
                {
                    NotificationManager.Instance.SetNotification("루비가 부족합니다.");
                }
                break;
            case 1:
                if (DataController.Instance.ruby >= 4000)
                {
                    DataController.Instance.ruby -= 4000;
                    DataController.Instance.goldBuffPotion += 30;
                    NotificationManager.Instance.SetNotification2("결계 무력화 30개 획득!!");
                }
                else
                {
                    NotificationManager.Instance.SetNotification("루비가 부족합니다.");
                }
                break;
            case 2:
                if (DataController.Instance.ruby >= 800)
                {
                    DataController.Instance.ruby -= 800;
                    DataController.Instance.autoClickPotion += 5;
                    NotificationManager.Instance.SetNotification2("정령의 가호 5개 획득!!");
                }
                else
                {
                    NotificationManager.Instance.SetNotification("루비가 부족합니다.");
                }
                break;
            case 3:
                if (DataController.Instance.ruby >= 4000)
                {
                    DataController.Instance.ruby -= 4000;
                    DataController.Instance.autoClickPotion += 30;
                    NotificationManager.Instance.SetNotification2("정령의 가호 30개 획득!!");
                }
                else
                {
                    NotificationManager.Instance.SetNotification("루비가 부족합니다.");
                }
                break;
        }
    }
    
    public void PurchaseDevilPakageItem(int i)
    {
        switch (i)
        {
            case 0:
                DataController.Instance.ruby += 2000;
                DataController.Instance.sapphire += 1000;
                DataController.Instance.devilStone += 1000;
                NotificationManager.Instance.SetNotification2("악마 패키지1 구매완료!!");
                
                DataController.Instance.inAppPurchase += 10000;
                break;
            case 1:
                DataController.Instance.ruby += 7000;
                DataController.Instance.sapphire += 3500;
                DataController.Instance.devilStone += 3500;
                NotificationManager.Instance.SetNotification2("악마 패키지2 구매완료!!");
                
                DataController.Instance.inAppPurchase += 30000;
                break;
            case 2:
                DataController.Instance.ruby += 20000;
                DataController.Instance.sapphire += 10000;
                DataController.Instance.devilStone += 10000;
                NotificationManager.Instance.SetNotification2("악마 패키지3 구매완료!!");
                
                DataController.Instance.inAppPurchase += 80000;
                break;
        }
    }

    public void PurchasePotionPakage()
    {
        DataController.Instance.autoClickPotion += 20;
        DataController.Instance.goldBuffPotion += 20;
        DataController.Instance.ruby += 800;
        
        NotificationManager.Instance.SetNotification2("물약 패키지 구매완료!!");
        
        DataController.Instance.inAppPurchase += 6000;
    }
}