using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowVersion : MonoBehaviour {
    private void Start()
    {
        GetComponent<Text>().text = "v " + Application.version;
    }
}
