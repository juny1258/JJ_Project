using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSound : MonoBehaviour {

	public Image SoundImage;
    
	private void OnEnable()
	{
		if (PlayerPrefs.GetFloat("Sound", 0) == 0)
        {
            SoundImage.sprite = Resources.Load("Sound1", typeof(Sprite)) as Sprite;
        }
        else if (PlayerPrefs.GetFloat("Sound", 0) == 1)
        {
            SoundImage.sprite = Resources.Load("Sound0", typeof(Sprite)) as Sprite;
        }
    }

    public void OnClick()
    {
        if (PlayerPrefs.GetFloat("Sound", 0) == 0)
        {
            PlayerPrefs.SetFloat("Sound", 1);
            SoundImage.sprite = Resources.Load("Sound0", typeof(Sprite)) as Sprite;
            AudioListener.volume = 0f;
        }
        else if (PlayerPrefs.GetFloat("Sound", 0) == 1)
        {
            PlayerPrefs.SetFloat("Sound", 0);
            SoundImage.sprite = Resources.Load("Sound1", typeof(Sprite)) as Sprite;
            AudioListener.volume = 1f;
        }
    }
}
