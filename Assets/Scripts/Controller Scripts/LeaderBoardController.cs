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

	// Achievements ID
	public const string score5 = "CgkIlY-bvcoNEAIQAg";
	public const string passTheScore30 = "CgkIlY-bvcoNEAIQAw";
	public const string unlockTheGreenBird = "CgkIlY-bvcoNEAIQBQ";
	public const string unlockTheDawnLevel = "CgkIlY-bvcoNEAIQBg";
	public const string becomeAcenturian = "CgkIlY-bvcoNEAIQBw";
	public const string unlockTheRedBird = "CgkIlY-bvcoNEAIQCA";
	public const string unlockTheMountainsLevel = "CgkIlY-bvcoNEAIQCQ";
	public const string unlockTheLakeLevel = "CgkIlY-bvcoNEAIQCg";
	public const string unlockTheSpringLevel = "CgkIlY-bvcoNEAIQCw";
	public const string unlockTheFarmLevel = "CgkIlY-bvcoNEAIQDA";
	public const string unlockTheWinterLevel = "CgkIlY-bvcoNEAIQDQ";
	public const string unlockTheEveningLevel = "CgkIlY-bvcoNEAIQDg";
	public const string unlockTheDarkLevel = "CgkIlY-bvcoNEAIQDw";
	public const string unlockTheRainyLevel = "CgkIlY-bvcoNEAIQEA";
	public const string becomeTheUltimateFlappy = "CgkIlY-bvcoNEAIQEQ";

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
			PlayGamesPlatform.Instance.ShowAchievementsUI ();
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

	void ReportScoreLocal (int score)
	{
		if (Social.localUser.authenticated)
		{
			Social.ReportScore (score, leaderBoardId, (bool success) =>
			{

			});
		}
	}

	void ReportProgressLocal (int score)
	{
		if (Social.localUser.authenticated)
		{
			
		}
	}
}