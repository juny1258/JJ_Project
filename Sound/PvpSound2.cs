using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpSound2 : MonoBehaviour {

	public AudioSource AudioSource;

	public AudioClip clip;

	// Use this for initialization
	void Start ()
	{
		EventManager.PlaySkillSoundEvent2 += PlaySkill;
	}

	private void OnDestroy()
	{
		EventManager.PlaySkillSoundEvent2 -= PlaySkill;
	}

	private void PlaySkill()
	{
		AudioSource.clip = clip;
		AudioSource.Play();
	}
}
