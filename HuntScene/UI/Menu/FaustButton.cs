using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaustButton : MonoBehaviour
{
	public GameObject RockObject;
	public GameObject FaustObject;

	public Animator MoveSceneAnimator;

	public AudioSource BackgroundSound;
	public AudioClip BackgroundClip;

	public GameObject BossBackground;
	public GameObject NomalBackground;

	private void OnEnable()
	{
		GetComponentInChildren<Text>().text = "도전하기(" + DataController.Instance.faustCount + "/10)";
	}

	public void StartGame()
	{
		if (!DataController.Instance.isFight)
		{
			if (DataController.Instance.faustCount > 0)
			{
				DataController.Instance.isFight = true;
				MoveSceneAnimator.Play("MoveScene", 0, 0);
				Invoke("FightFaust", 0.5f);
			}
			else
			{
				NotificationManager.Instance.SetNotification("도전 횟수가 부족합니다.");
			}	
		}
	}
	
	private void FightFaust()
	{
		NomalBackground.SetActive(false);
		BossBackground.SetActive(true);
		BackgroundSound.clip = BackgroundClip;
		BackgroundSound.Play();
		RockObject.SetActive(false);
		FaustObject.SetActive(true);
		DataController.Instance.faustCount--;
		MenuManager.Instance.Close();
	}
}
