using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatText : MonoBehaviour {

	private Vector3 direction;
	private float fadeTime;

	private void Start()
	{
	}

	public void Initialize()
	{
		StartCoroutine(FadeOut());
	}

	private IEnumerator FadeOut()
	{
		var rate = 1.0f;
		var progress = 0.0f;

		while (progress <= 1.0f)
		{
			
			progress += rate * Time.deltaTime;

			if (progress > 0.9f)
			{
				Destroy(gameObject);
			}

			yield return null;
		}
	}
}