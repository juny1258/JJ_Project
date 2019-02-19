using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompensationButton : MonoBehaviour
{

	public GameObject CompensationPanel;

	public void OKButton()
	{
		CompensationPanel.SetActive(false);
	}

	public void OnAdClick()
	{
		AdMob.Instance.ShowCompensationAd();
		CompensationPanel.SetActive(false);
	}
}
