using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingEffect : MonoBehaviour
{
    public Text SoundImage;
    
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("IsEffect", 0) == 0)
        {
            SoundImage.text = "ON";
        }
        else if (PlayerPrefs.GetInt("IsEffect", 0) == 1)
        {
            SoundImage.text = "OFF";
        }
    }

    public void OnClick()
    {
        if (PlayerPrefs.GetInt("IsEffect", 0) == 0)
        {
            PlayerPrefs.SetInt("IsEffect", 1);
            SoundImage.text = "OFF";
        }
        else if (PlayerPrefs.GetInt("IsEffect", 0) == 1)
        {
            PlayerPrefs.SetInt("IsEffect", 0);
            SoundImage.text = "ON";
        }
    }
}
