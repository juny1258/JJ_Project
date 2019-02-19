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
                break;
            case 1:
                DataController.Instance.ruby += 2400;
                break;
            case 2:
                DataController.Instance.ruby += 5000;
                break;
            case 3:
                DataController.Instance.ruby += 28000;
                break;
            case 4:
                DataController.Instance.ruby += 60000;
                break;
        }
    }
    
    public void PurchaseSapphireItem(int i)
    {
        switch (i)
        {
            case 0:
                DataController.Instance.sapphire += 200;
                break;
            case 1:
                DataController.Instance.sapphire += 1200;
                break;
            case 2:
                DataController.Instance.sapphire += 2500;
                break;
            case 3:
                DataController.Instance.sapphire += 14000;
                break;
            case 4:
                DataController.Instance.sapphire += 30000;
                break;
        }
    }
}