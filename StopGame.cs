using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void OnClick()
	{
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;	
		}
		else
		{
			Time.timeScale = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
