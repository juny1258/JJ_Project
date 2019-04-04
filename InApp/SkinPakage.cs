using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPakage : MonoBehaviour {

	public GameObject Panel;
	public int index;
	
	private void OnEnable()
	{
		Panel.SetActive(PlayerPrefs.GetFloat("Skin_" + index, 0) == 1);
	}

	public void PurchasdSkinPakage()
	{
		DataController.Instance.ruby += 30000;
		DataController.Instance.skinDamage += 5;
		DataController.Instance.skinCriticalPer += 10;
		
		DataController.Instance.UpdateDamage();
		DataController.Instance.UpdateCritical();

		DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();
		
		PlayerPrefs.SetFloat("Skin_" + index, 1);
		
		DataController.Instance.skinIndex = index;
        
		EventManager.Instance.SelectSkin();	
        
		NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPackage[4]);
		
		DataController.Instance.inAppPurchase += 80000;
		
		Panel.SetActive(PlayerPrefs.GetFloat("Skin_" + index, 0) == 1);
	}
	
	public void PurchasdSkin3Pakage()
	{
		DataController.Instance.ruby += 30000;
		DataController.Instance.skinDamage += 5;
		DataController.Instance.skinCriticalRising += 2;
		
		DataController.Instance.UpdateDamage();
		DataController.Instance.UpdateCritical();

		DataController.Instance.nowPlayerHP = DataController.Instance.GetPlayerHP();
		
		PlayerPrefs.SetFloat("Skin_" + index, 1);
		
		DataController.Instance.skinIndex = index;
        
		EventManager.Instance.SelectSkin();	
        
		NotificationManager.Instance.SetNotification2(LocalManager.Instance.GetPackage[4]);
		
		DataController.Instance.inAppPurchase += 80000;
		
		Panel.SetActive(PlayerPrefs.GetFloat("Skin_" + index, 0) == 1);
	}
}
