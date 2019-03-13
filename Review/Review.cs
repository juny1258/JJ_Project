using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Review : MonoBehaviour
{

	public GameObject ReviewPanel;

	public void OnReviewClick()
	{
		Application.OpenURL("market://details?id=com.Juny.Devil");
		ReviewPanel.SetActive(false);
	}

	public void OnClose()
	{
		ReviewPanel.SetActive(false);
	}
}
