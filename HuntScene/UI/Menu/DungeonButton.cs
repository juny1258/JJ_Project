using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonButton : MonoBehaviour {

	public GameObject RockObject;
	public GameObject MonsterSpwan;
	
	public GameObject NotClearPanel;

	public int index;

	private void OnEnable()
	{
		NotClearPanel.SetActive(index > DataController.Instance.finalDungeonLevel);
	}

	public void StartDungeon()
	{
		DataController.Instance.dungeonLevel = index;
		MenuManager.Instance.Close();
		RockObject.SetActive(false);
		MonsterSpwan.SetActive(true);
	}

	public void SkipDungeon()
	{
		MenuManager.Instance.Close();
		print("스킵");
	}
}
