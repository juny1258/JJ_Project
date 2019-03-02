using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvpSound : MonoBehaviour {
	
	public AudioSource AudioSource;

	public AudioClip clip;

	// Use this for initialization
	void Start ()
	{
		EventManager.PlaySkillSoundEvent += PlaySkill;
	}

	private void OnDestroy()
	{
		EventManager.PlaySkillSoundEvent -= PlaySkill;
	}

	private void PlaySkill()
	{
		AudioSource.clip = clip;
		AudioSource.Play();
	}
	
}
