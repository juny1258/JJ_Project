using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPakage : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel;

    private void OnEnable()
    {
        Panel.SetActive(PlayerPrefs.GetFloat("IsSkillPurchase", 0) == 1);

        if (PlayerPrefs.GetFloat("IsSkillPurchase", 0) == 1)
        {
            Panel1.SetActive(false);
        }
    }

    public void PurchaseSkillPakage()
    {
        DataController.Instance.sapphire += 4030;
        PlayerPrefs.SetFloat("IsSkillPurchase", 1);

        NotificationManager.Instance.SetNotification2("스킬 패키지 구매완료!!");
        
        DataController.Instance.inAppPurchase += 14000;
        
        Panel.SetActive(PlayerPrefs.GetFloat("IsSkillPurchase", 0) == 1);
    }
}