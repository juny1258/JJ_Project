using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine;

public class FirebaseManager : MonoBehaviour {
	
	private static FirebaseManager _instance;

	public static FirebaseManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<FirebaseManager>();
			}

			return _instance;
		}
	}

	public DatabaseReference Reference;
	
	private void Awake()
	{
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://devilhunter-b89af.firebaseio.com/");

		Reference = FirebaseDatabase.DefaultInstance.RootReference;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
}
