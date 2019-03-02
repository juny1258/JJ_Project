using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowSkill : MonoBehaviour
{
    public GameObject ShadowPartner;
    public Text TimeText;

    private float shadowTime;

    public Animator ShadowPlayer;
    
    public GameObject NotPurchasePanel;

    private void Start()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_3 == 0);
        
        EventManager.UpgradeSkillEvent += UpSkill;
    }

    private void UpSkill()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_3 == 0);
    }

    private void OnDestroy()
    {
        EventManager.UpgradeSkillEvent -= UpSkill;
    }

    private void Update()
    {
        if (DataController.Instance.skill_3_cooltime > 0)
        {
            TimeText.gameObject.SetActive(true);
            DataController.Instance.skill_3_cooltime -= Time.deltaTime;
            var min = (int)DataController.Instance.skill_3_cooltime / 60;
            var sec = (int) DataController.Instance.skill_3_cooltime - 60 * min;
            TimeText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            TimeText.gameObject.SetActive(false);
        }

        if (shadowTime > 0)
        {
            shadowTime -= 1 * Time.deltaTime;
            if (shadowTime < 0)
            {
                DataController.Instance.isShadowSkill = false;
                ShadowPartner.SetActive(false);
            }
        }
    }

    public void PlaySkill()
    {
        if (DataController.Instance.skill_3_cooltime <= 0)
        {
            if (DataController.Instance.isFight)
            {
                ShadowPartner.SetActive(true);
            
                ShadowPlayer.Play("Attack" + DataController.Instance.costumeIndex, 0, 1f);
                shadowTime = DataController.Instance.skill_3_time;
                DataController.Instance.isShadowSkill = true;
                DataController.Instance.skill_3_cooltime = 180 - 9 * (DataController.Instance.collectionCoolTime / 5);
                EventManager.Instance.PlaySkill();
            }
            else
            {
                NotificationManager.Instance.SetNotification("지금은 사용할 수 없습니다.");
            }
        }
    }
}