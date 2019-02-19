using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyExplosion : MonoBehaviour {

	public GameObject[] HolyObjects;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine(PlaySkill());
	}

	private IEnumerator PlaySkill()
	{
		int i = 0;
		while (i < 14)
		{
			HolyObjects[i].SetActive(true);
			i++;
			
			yield return new WaitForSeconds(0.1f);
		}
		
		Invoke("DeleteObject", 3f);
	}

	private void DeleteObject()
	{
		Destroy(gameObject);
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}
}
