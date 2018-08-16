using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using Google;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SceneManagement;
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

	void OnEnable ()
	{
		SceneManager.sceneLoaded += this.OnLoadCallBack;
	}

	void OnLoadCallBack (Scene scene, LoadSceneMode sceneMode)
	{
		ReportScoreLocal (GameController.instance.GetHighScore ());
		ReportProgressLocal (GameController.instance.GetHighScore ());
	}

	void OnDisable ()
	{
		SceneManager.sceneLoaded -= this.OnLoadCallBack;
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
			//PlayGamesPlatform.Instance.ShowAchievementsUI ();

			Social.ShowAchievementsUI();			
		}
		else
		{
			Social.localUser.Authenticate ((bool success) =>
			{

			});
		}
	}

	public void OpenLeaderBoard ()
	{
		if (Social.localUser.authenticated)
		{
			//PlayGamesPlatform.Instance.ShowLeaderboardUI (leaderBoardId);

			Social.ShowLeaderboardUI();
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
			if (score >= 5 && score < 30)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 30 && score < 50)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 50 && score < 100)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 100 && score < 150)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeAcenturian, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 150 && score < 200)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeAcenturian, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheRedBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheMountainsLevel, (double) score, (bool success) =>
				{

				});

			}
			else if (score >= 200 && score < 300)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeAcenturian, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheRedBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheMountainsLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheLakeLevel, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 300 && score < 400)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeAcenturian, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheRedBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheMountainsLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheLakeLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheSpringLevel, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 400 && score < 500)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeAcenturian, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheRedBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheMountainsLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheLakeLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheSpringLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheFarmLevel, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 500 && score < 600)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeAcenturian, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheRedBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheMountainsLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheLakeLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheSpringLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheFarmLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheWinterLevel, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 600 && score < 700)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeAcenturian, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheRedBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheMountainsLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheLakeLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheSpringLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheFarmLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheWinterLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheEveningLevel, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 700 && score < 800)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeAcenturian, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheRedBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheMountainsLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheLakeLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheSpringLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheFarmLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheWinterLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheEveningLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDarkLevel, (double) score, (bool success) =>
				{

				});
			}
			else if (score >= 800)
			{
				Social.ReportProgress (score5, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (passTheScore30, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheGreenBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDawnLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeAcenturian, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheRedBird, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheMountainsLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheLakeLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheSpringLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheFarmLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheWinterLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheEveningLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheDarkLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (unlockTheRainyLevel, (double) score, (bool success) =>
				{

				});

				Social.ReportProgress (becomeTheUltimateFlappy, (double) score, (bool success) =>
				{

				});
			}
		}
	}
}