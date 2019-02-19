using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSkill : MonoBehaviour {

	public GameObject SkillObject;

	public GameObject Meteor;
    
	public GameObject NotPurchasePanel;

	public Text TimeText;

	private void Start()
	{
		NotPurchasePanel.SetActive(DataController.Instance.skill_5 == 0);
        
		EventManager.UpgradeSkillEvent += () => { NotPurchasePanel.SetActive(DataController.Instance.skill_5 == 0); };
	}

}
