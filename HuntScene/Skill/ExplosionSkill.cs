using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionSkill : MonoBehaviour
{
    public GameObject SkillObject;

    public GameObject Meteor;
    
    public GameObject NotPurchasePanel;

    public Text TimeText;

    private void Start()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_5 == 0);
        
        EventManager.UpgradeSkillEvent += UpSkill;
    }

    private void UpSkill()
    {
        NotPurchasePanel.SetActive(DataController.Instance.skill_5 == 0);
    }

    private void OnDestroy()
    {
        EventManager.UpgradeSkillEvent -= UpSkill;
    }

    public void PlaySkill()
    {
        if (DataController.Instance.skill_5_cooltime <= 0)
        {
            DataController.Instance.skill_5_cooltime = 180 - 9 * (DataController.Instance.collectionCoolTime / 5);
            Instantiate(Meteor, new Vector3(-7.07f, 7.66f, 0), Quaternion.Euler(0, 0, -135));
            Invoke("DelaySkill", 0.6f);
            GetComponent<AudioSource>().Play();   
            EventManager.Instance.PlaySkill();
        }
    }

    public void DelaySkill()
    {
        Instantiate(SkillObject, new Vector3(2.07f, -3.3f, 0), Quaternion.Euler(75, 0, 0));
        EventManager.Instance.UseSkill(3);
        EventManager.Instance.ShackScreen(0.15f, 1f);
    }

    private void Update()
    {
        if (DataController.Instance.skill_5_cooltime > 0)
        {
            TimeText.gameObject.SetActive(true);
            DataController.Instance.skill_5_cooltime -= Time.deltaTime;
            var min = (int)DataController.Instance.skill_5_cooltime / 60;
            var sec = (int) DataController.Instance.skill_5_cooltime - 60 * min;
            TimeText.text = string.Format("{0:00}:{1:00}", min, sec);
        }
        else
        {
            TimeText.gameObject.SetActive(false);
        }
    }
}