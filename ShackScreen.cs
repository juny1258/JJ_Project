using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShackScreen : MonoBehaviour {

	Vector3 originPos;
	
	void Start () {
		originPos = transform.localPosition;

		EventManager.ShackScreenEvent += Explosion1;
	}

	private void Explosion1(float amount, float duration)
	{
		StartCoroutine(Shake(amount, duration));
	}

	public IEnumerator Shake(float _amount, float _duration)
	{
		float timer = 0;
		while (timer <= _duration)
		{
			transform.localPosition = (Vector3) Random.insideUnitCircle * _amount + originPos;

			timer += Time.deltaTime;
			yield return null;
		}

		transform.localPosition = originPos;
	}
}
