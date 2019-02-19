using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSkillObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("DeleteObject", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void DeleteObject()
	{
		Destroy(gameObject);
	}
}
