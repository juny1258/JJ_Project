using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartButton : MonoBehaviour
{

	public GameObject LoadingPanel;

	public void StartButton()
	{
		LoadingPanel.SetActive(true);
		
		SceneManager.LoadScene(1);
	}

}
