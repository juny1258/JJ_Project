using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPlayer : MonoBehaviour
{

	public Animator ani;
	
	private void Start()
	{
		SetCostume();
	}

	private void OnEnable()
	{
		SetCostume();
	}

	private void SetCostume()
	{
		print(0);
		if (DataController.Instance.skinIndex == 0)
		{
			print(1);
			ani.Play("Attack" + DataController.Instance.costumeIndex, 0, 1);
		}
		else
		{
			print(2);
			ani.Play("SkinAttack" + DataController.Instance.skinIndex, 0, 1);
		}
	}
}
