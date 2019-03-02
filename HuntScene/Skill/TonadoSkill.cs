using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TonadoSkill : MonoBehaviour
{
    public GameObject SkillObject;
    
    public GameObject NotPurchasePanel;
    public Text TimeText;

    private void Start()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_2 == 0);
        
        EventManager.UpgradeSkillEvent += UpSkill;
    }

    private void UpSkill()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_2 == 0);
    }

    private void OnDestroy()
    {
        EventManager.UpgradeSkillEvent -= UpSkill;
    }

    public void PlaySkill_2()
    {
        if (DataController.Instance.skill_2_cooltime <= 0)
        {
            Instantiate(SkillObject, new Vector3(0, 0, 0), Quaternion.identity);
            EventManager.Instance.UseSkill(2);
            DataController.Instance.skill_2_cooltime = 180 - 9 * (DataController.Instance.collectionCoolTime / 5);
            EventManager.Instance.PlaySkill();
        }
    }

    private void Update()
    {
        if (DataController.Instance.skill_2_cooltime > 0)
        {
            TimeText.gameObject.SetActive(true);
            DataController.Instance.skill_2_cooltime -= Time.deltaTime;
            var min = (int)DataController.Instance.skill_2_cooltime / 60;
            var sec = (int) DataController.Instance.skill_2_cooltime - 60 * min;
            TimeText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            TimeText.gameObject.SetActive(false);
        }
    }
}