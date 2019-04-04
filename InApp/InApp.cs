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
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetRuby[0]);

                DataController.Instance.inAppPurchase += 1000;
                break;
            case 1:
                DataController.Instance.ruby += 2400;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetRuby[1]);
                
                DataController.Instance.inAppPurchase += 5000;
                break;
            case 2:
                DataController.Instance.ruby += 5000;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetRuby[2]);
                
                
                DataController.Instance.inAppPurchase += 10000;
                break;
            case 3:
                DataController.Instance.ruby += 28000;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetRuby[3]);
                
                
                DataController.Instance.inAppPurchase += 49000;
                break;
            case 4:
                DataController.Instance.ruby += 60000;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetRuby[4]);
                
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
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetSapphire[0]);
                
                DataController.Instance.inAppPurchase += 1000;
                break;
            case 1:
                DataController.Instance.sapphire += 1200;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetSapphire[1]);
                
                DataController.Instance.inAppPurchase += 5000;
                break;
            case 2:
                DataController.Instance.sapphire += 2500;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetSapphire[2]);
                
                DataController.Instance.inAppPurchase += 10000;
                break;
            case 3:
                DataController.Instance.sapphire += 14000;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetSapphire[3]);
                
                DataController.Instance.inAppPurchase += 49000;
                break;
            case 4:
                DataController.Instance.sapphire += 30000;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetSapphire[4]);
                
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
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetScroll[0]);
                
                DataController.Instance.inAppPurchase += 1000;
                break;
            case 1:
                DataController.Instance.skipCoupon += 30;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetScroll[1]);
                
                DataController.Instance.inAppPurchase += 5000;
                break;
            case 2:
                DataController.Instance.skipCoupon += 65;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetScroll[2]);
                
                DataController.Instance.inAppPurchase += 10000;
                break;
            case 3:
                DataController.Instance.skipCoupon += 350;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetScroll[3]);
                
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
                    NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPotion[0]);
                }
                else
                {
                    NotificationManager.Instance.SetNotification(LocalManager.Instance.LessRuby);
                }
                break;
            case 1:
                if (DataController.Instance.ruby >= 4000)
                {
                    DataController.Instance.ruby -= 4000;
                    DataController.Instance.goldBuffPotion += 30;
                    NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPotion[1]);
                }
                else
                {
                    NotificationManager.Instance.SetNotification(LocalManager.Instance.LessRuby);
                }
                break;
            case 2:
                if (DataController.Instance.ruby >= 800)
                {
                    DataController.Instance.ruby -= 800;
                    DataController.Instance.autoClickPotion += 5;
                    NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPotion[2]);
                }
                else
                {
                    NotificationManager.Instance.SetNotification(LocalManager.Instance.LessRuby);
                }
                break;
            case 3:
                if (DataController.Instance.ruby >= 4000)
                {
                    DataController.Instance.ruby -= 4000;
                    DataController.Instance.autoClickPotion += 30;
                    NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPotion[3]);
                }
                else
                {
                    NotificationManager.Instance.SetNotification(LocalManager.Instance.LessRuby);
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
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPackage[0]);
                
                DataController.Instance.inAppPurchase += 10000;
                break;
            case 1:
                DataController.Instance.ruby += 7000;
                DataController.Instance.sapphire += 3500;
                DataController.Instance.devilStone += 3500;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPackage[1]);
                
                DataController.Instance.inAppPurchase += 30000;
                break;
            case 2:
                DataController.Instance.ruby += 20000;
                DataController.Instance.sapphire += 10000;
                DataController.Instance.devilStone += 10000;
                NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPackage[2]);
                
                DataController.Instance.inAppPurchase += 80000;
                break;
        }
    }

    public void PurchasePotionPakage()
    {
        DataController.Instance.autoClickPotion += 20;
        DataController.Instance.goldBuffPotion += 20;
        DataController.Instance.ruby += 800;
        
        NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPackage[3]);
        
        DataController.Instance.inAppPurchase += 6000;
    }
}