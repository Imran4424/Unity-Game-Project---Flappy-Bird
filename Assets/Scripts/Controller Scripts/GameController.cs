using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance;

	public const string High_Score = "High Score";
	public const string Selected_Bird = "Selected Bird";
	public const string Green_Bird = "Green Bird";
	public const string Red_Bird = "Red Bird";

	void Awake()
	{
		MakeSingleton();
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void MakeSingleton()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void IsTheGameStartedForTheFirstTime()
	{
		
	}
}
