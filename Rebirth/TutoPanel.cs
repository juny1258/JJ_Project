using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoPanel : MonoBehaviour
{

	public GameObject TutoP;

	public void OKButton()
	{
		Time.timeScale = 1;
		TutoP.SetActive(false);
	}
}
