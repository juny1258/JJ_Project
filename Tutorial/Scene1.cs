using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : MonoBehaviour
{

	public Animator StartTutorialAnimator;

	public GameObject StartInfoPanel;

	public GameObject TutorialPanel;

	public GameObject SkipButton;

	public static bool isSkiped;

	// Use this for initialization
	void Start () {
		StartTutorialAnimator.Play("Tutorial", 0, 0);
		Invoke("StartTutorial", 28);
		Invoke("ShowSkipButton", 10);
	}

	private void StartTutorial()
	{
		if (!isSkiped)
		{
			StartInfoPanel.SetActive(false);
			TutorialPanel.SetActive(true);	
		}
	}

	private void ShowSkipButton()
	{
		SkipButton.SetActive(true);
	}
}
