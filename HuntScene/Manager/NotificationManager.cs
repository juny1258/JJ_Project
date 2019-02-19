using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour {

	private static NotificationManager _instance;

	public static NotificationManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<NotificationManager>();
			}

			return _instance;
		}
	}

	public Animator NotificatioAnimator;
	public Text NotificationText;

	public Animator NotificationAnimator2;
	public Text NotificationText2;

	public void SetNotification(string text)
	{
		NotificationText.text = text;
		NotificatioAnimator.Play("NotificationAnimation", -1, 0);
	}
	
	public void SetNotification2(string text)
	{
		NotificationText2.text = text;
		NotificationAnimator2.Play("Notification2", -1, 0);
	}
}
