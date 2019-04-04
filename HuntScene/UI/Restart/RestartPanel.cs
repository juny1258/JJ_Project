using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPanel : MonoBehaviour
{
    public GameObject RestartButton;

    private void OnEnable()
    {
        RestartButton.transform.localPosition = new Vector3(Random.Range(-682.21f, 682.21f), Random.Range(389.8f, -389.8f), 0);
        Time.timeScale = 0;
    }
}