using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkill : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, 0, -40f);
	}
}
