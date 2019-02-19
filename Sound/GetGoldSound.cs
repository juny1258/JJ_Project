using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGoldSound : MonoBehaviour
{

	private AudioSource AudioSource;
	
	private void Start()
	{
		AudioSource = GetComponent<AudioSource>();
	}

	public void GetGold()
	{
		AudioSource.Play();
	}
}
