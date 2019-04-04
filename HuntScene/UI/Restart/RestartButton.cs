using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public GameObject RestartPanel;
    
    public void OnRestartClick()
    {
        Time.timeScale = 1;
        RestartPanel.SetActive(false);
    }
}
