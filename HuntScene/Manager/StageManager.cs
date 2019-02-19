using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{

	public Text StageText; 
	
	private void Start()
	{
		StageText.text = "Stage " + DataController.Instance.nowStage;
		
		EventManager.Instance.StartHunt();
	}
}
