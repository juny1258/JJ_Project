using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCollider : MonoBehaviour
{

	public float speed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wall")
		{
			Destroy(gameObject);
		}
	}
}
