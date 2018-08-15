using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class LeaderBoardController : MonoBehaviour
{

	public static LeaderBoardController instance;

	public const string leaderBoardId = "CgkIlY-bvcoNEAIQAQ";

	void Awake ()
	{
		MakeSingleton ();
	}

	// Use this for initialization
	void Start ()
	{
		PlayGamesPlatform.Activate ();
	}

	// Update is called once per frame
	void Update ()
	{

	}

	// making C# script singleton
	void MakeSingleton ()
	{
		if (instance != null)
		{
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void ConnectGooglePlayGames ()
	{
		if (Social.localUser.authenticated)
		{

		}
		else
		{
			Social.localUser.Authenticate ((bool success) =>
			{
				if (success)
				{
					Debug.Log ("successfully Log In");
				}
				else
				{
					Debug.Log ("Log In Failed");
				}
			});
		}
	}

	public void OpenLeaderBoard ()
	{
		if (Social.localUser.authenticated)
		{
			PlayGamesPlatform.Instance.ShowLeaderboardUI (leaderBoardId);
		}
	}

	
}