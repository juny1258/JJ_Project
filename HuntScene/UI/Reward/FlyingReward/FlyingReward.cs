using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingReward : MonoBehaviour
{

	public GameObject RewardPanel;
	public Animator MoveAnimation;

	private void OnMouseUp()
	{
		if (!DataController.Instance.isMenuOpen)
		{
			RewardPanel.SetActive(true);
			MoveAnimation.Play("Idle", 0, 0);
			Time.timeScale = 0;	
		}
	}
}
