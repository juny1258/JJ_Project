using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaustButton : MonoBehaviour
{
	public GameObject RockObject;
	public GameObject FaustObject;

	public Animator MoveSceneAnimator;

	public AudioSource BackgroundSound;
	public AudioClip BackgroundClip;

	public GameObject BossBackground;
	public GameObject NomalBackground;
	
	public void StartGame()
	{
		MoveSceneAnimator.Play("MoveScene", 0, 0);
		Invoke("FightFaust", 0.5f);
	}
	
	private void FightFaust()
	{
		NomalBackground.SetActive(false);
		BossBackground.SetActive(true);
		BackgroundSound.clip = BackgroundClip;
		BackgroundSound.Play();
		RockObject.SetActive(false);
		FaustObject.SetActive(true);
		DataController.Instance.isFight = true;
		MenuManager.Instance.Close();
	}
}
