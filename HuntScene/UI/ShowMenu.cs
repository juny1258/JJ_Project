using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{

	public GameObject Panel;

	public void OpenPanel()
	{
		Panel.SetActive(true);
	}
}
