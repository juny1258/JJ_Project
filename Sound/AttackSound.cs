using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSound : MonoBehaviour {

	public void PlayAttackSound()
	{
		gameObject.GetComponent<AudioSource>().Play();
	}
}
