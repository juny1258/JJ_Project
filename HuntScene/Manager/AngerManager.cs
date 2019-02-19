using System;
using UnityEngine;
using UnityEngine.UI;

public class AngerManager : MonoBehaviour
{

	public Slider AngerSlider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!DataController.Instance.isAnger)
		{
			AngerSlider.value = DataController.Instance.angerGauge;
		}
		else
		{
			AngerSlider.value = DataController.Instance.angerGauge;
		}
	}
}
