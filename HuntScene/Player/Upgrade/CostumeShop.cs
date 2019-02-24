using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostumeShop : MonoBehaviour {

	public Text HpText;
	public GameObject SelectPanel;

	public GameObject NotClearPanel;

	public int index;
    
	private int[] plusHp = {0, 20, 40, 60, 80, 100, 150, 200, 300, 500};

	private void Start()
	{
		EventManager.SelectCostumeEvent += () =>
		{
			HpText.text = "체력 + " + plusHp[index] + "%";
            
			SelectPanel.SetActive(DataController.Instance.costumeIndex == index);
            
			NotClearPanel.SetActive(DataController.Instance.masterCostumeIndex < index);
		};
	}

	private void OnEnable()
	{
		HpText.text = "체력 + " + plusHp[index] + "%";
        
		SelectPanel.SetActive(DataController.Instance.costumeIndex == index);

		NotClearPanel.SetActive(DataController.Instance.masterCostumeIndex < index);
	}

	public void SelectItem()
	{   
		DataController.Instance.costumeIndex = index;
        
		EventManager.Instance.SelectCostume();
	}
}
