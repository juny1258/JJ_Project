using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{

    public GameObject StartInfoPanel;

    public GameObject TutorialPanel;

    public void OnSkip()
    {
        StartInfoPanel.SetActive(false);
        TutorialPanel.SetActive(true);

        Scene1.isSkiped = true;
    }
}
