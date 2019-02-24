using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour {

	public GameObject SelectPanel;

	public int index;

	private void Start()
	{
		EventManager.SelectSkinEvent += () =>
		{
			SelectPanel.SetActive(DataController.Instance.skinIndex == index);
		};
	}

	private void OnEnable()
	{
		SelectPanel.SetActive(DataController.Instance.skinIndex == index);
	}

	public void SelectItem()
	{   
		DataController.Instance.skinIndex = index;
        
		EventManager.Instance.SelectSkin();
	}
}
