using System.Collections;
using System.Collections.Generic;
using Google;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class LeaderBoardController : MonoBehaviour
{
	public static LeaderBoardController instance;

	public const string leaderBoardId = GPGSIds.leaderboard_flappy_the_bird_leaderboard;

	// Achievements ID
	public const string score5 = GPGSIds.achievement_score_5;
	public const string passTheScore30 = GPGSIds.achievement_pass_the_score_30;
	public const string unlockTheGreenBird = GPGSIds.achievement_unlock_the_green_bird;
	public const string unlockTheDawnLevel = GPGSIds.achievement_unlock_the_dawn_level;
	public const string becomeAcenturian = GPGSIds.achievement_become_a_centurian;
	public const string unlockTheRedBird = GPGSIds.achievement_unlock_the_red_bird;
	public const string unlockTheMountainsLevel = GPGSIds.achievement_unlock_the_mountains_level;
	public const string unlockTheLakeLevel = GPGSIds.achievement_unlock_the_lake_level;
	public const string unlockTheSpringLevel = GPGSIds.achievement_unlock_the_spring_level;
	public const string unlockTheFarmLevel = GPGSIds.achievement_unlock_farm_level;
	public const string unlockTheWinterLevel = GPGSIds.achievement_unlock_the_winter_level;
	public const string unlockTheEveningLevel = GPGSIds.achievement_unlock_the_evening_level;
	public const string unlockTheDarkLevel = GPGSIds.achievement_unlock_the_dark_level;
	public const string unlockTheRainyLevel = GPGSIds.achievement_unlock_the_rainy_level;
	public const string becomeTheUltimateFlappy = GPGSIds.achievement_became_the_ultimate_flappy;

	void Awake ()
	{
		MakeSingleton ();
	}

	// Use this for initialization
	void Start ()
	{
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder ().Build ();
		PlayGamesPlatform.InitializeInstance (config);
		PlayGamesPlatform.Activate ();
	}

	// Event Subscription On a Scene Load
	void OnEnable ()
	{
		SceneManager.sceneLoaded += this.OnLoadCallBack;
	}

	// The Event
	void OnLoadCallBack (Scene scene, LoadSceneMode sceneMode)
	{
		ReportScoreLocal (GameController.instance.GetHighScore ());
		ReportProgressLocal (GameController.instance.GetHighScore ());
	}

	// Event unsubscribe On a Scene Leave
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
			DontDestroyOnLoad (instance);
		}
	}

	public void ConnectGooglePlayGames ()
	{

		if (!Social.localUser.authenticated)
		{
			//Debug.Log ("Not Log In");

			Social.localUser.Authenticate ((bool success) =>
			{

			});
		}
		
	}

	public void ShowAchievements ()
	{
		if (Social.localUser.authenticated)
		{
			Social.ShowAchievementsUI ();
		}
	}

	public void OpenLeaderBoard ()
	{
		//Debug.Log ("In the function");

		if (Social.localUser.authenticated)
		{
			//PlayGamesPlatform.Instance.ShowLeaderboardUI (leaderBoardId);

			Social.ShowLeaderboardUI ();
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