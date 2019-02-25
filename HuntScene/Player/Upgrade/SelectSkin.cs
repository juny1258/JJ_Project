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
		if (index > 0)
		{
			if (PlayerPrefs.GetFloat("Skin_" + index, 0) == 1)
			{
				DataController.Instance.skinIndex = index;
        
				EventManager.Instance.SelectSkin();	
			}
			else
			{
				NotificationManager.Instance.SetNotification("스킨 구매 후 착용할 수 있습니다.");
			}
		}
		else
		{
			DataController.Instance.skinIndex = index;
        
			EventManager.Instance.SelectSkin();	
		}
	}
}
