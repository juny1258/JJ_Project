using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour
{
	private static CombatTextManager instance;

	public GameObject BaseDamage;
	public GameObject CriticalDamage;

	public Transform canvasTransform;

	public static CombatTextManager Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<CombatTextManager>();
			}

			return instance;
		}
	}

	public void CreateText(Vector3 position, string text, bool isCritical)
	{
		if (!isCritical)
		{
			var sct = Instantiate(BaseDamage, position, Quaternion.identity);

			sct.transform.SetParent(canvasTransform);

			sct.GetComponentInChildren<CombatText>().Initialize();
			sct.GetComponentInChildren<Text>().text = text;	
		}
		else
		{
			var sct = Instantiate(CriticalDamage, position, Quaternion.identity);

			sct.transform.SetParent(canvasTransform);

			sct.GetComponentInChildren<CombatText>().Initialize();
			sct.GetComponentInChildren<Text>().text = text;
		}
	}
}