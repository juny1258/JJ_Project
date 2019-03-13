using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSkin : MonoBehaviour
{
	public GameObject EvnetSkinObject;

	private void OnEnable()
	{
		if (PlayerPrefs.GetFloat("Skin_100") == 0)
		{
			EvnetSkinObject.SetActive(false);
		}
		else
		{
			EvnetSkinObject.SetActive(true);
		}
	}
}
