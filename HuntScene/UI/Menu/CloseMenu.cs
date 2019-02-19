using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{

	public GameObject Panel;

	public void OnCloseButton()
	{
		Panel.SetActive(false);
	}
}
