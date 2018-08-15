using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using GooglePlayGames.BasicApi;


public class LeaderBoardController : MonoBehaviour
{

	public static LeaderBoardController instance;

	public const string leaderBoardId = "CgkIlY-bvcoNEAIQAQ";

	void Awake()
	{
		MakeSingleton();
	}

	// Use this for initialization
	void Start ()
	{
		PlayGamesPlatform.Activate();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	// making C# script singleton
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

	public void ConnectGooglePlayGames()
	{
		
	}
}