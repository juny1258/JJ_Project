using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOK : MonoBehaviour
{

	public GameObject GetItemPanel;

	public void OnClick()
	{
		GetItemPanel.SetActive(false);
	}
}
