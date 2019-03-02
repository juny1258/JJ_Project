using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour {

	public Text LoadingText;
	bool IsDone;
	float fTime;
	AsyncOperation async_operation;
 
	void Start()
	{
		StartCoroutine("StartLoad");
	}
 
	void Update()
	{
		fTime += Time.deltaTime;
		if (fTime <= 2f)
		{
			LoadingText.text = Math.Round(fTime * 50, 0) + "%";	
		}
		else
		{
			LoadingText.text = "100%";
		}
 
		if (fTime >= 2)
		{
			async_operation.allowSceneActivation = true;
		}
	}
 
	public IEnumerator StartLoad()
	{
		async_operation = SceneManager.LoadSceneAsync(1);
		async_operation.allowSceneActivation = false;
 
		if (IsDone == false)
		{
			IsDone = true;
 
			while (async_operation.progress < 0.9f)
			{
				LoadingText.text = Math.Round(async_operation.progress * 100, 0) + "%";
				
				yield return true;
			}
		}
	}
}
