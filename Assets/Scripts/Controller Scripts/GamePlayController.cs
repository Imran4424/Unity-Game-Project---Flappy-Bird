﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour
{

	public static GamePlayController instance;

	[SerializeField]
	private Text scoreText, endScore, bestScore, gemScoreText;

	[SerializeField]
	private Button pauseGameButton, resumeGameButton, saveMeButton;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel, saveMePanel;

	[SerializeField]
	private GameObject[] birds;

	[SerializeField]
	private Sprite[] medals;

	[SerializeField]
	private Image medalImage;

	public bool gameStarted;
	public bool youCanPause = false;


	void Awake ()
	{
		MakeInstance ();

		birds[GameController.instance.GetSelectedBird ()].SetActive (true);

		Time.timeScale = 0f;
		gameStarted = true;
	}

	void GemScore ()
	{
		//working fine, no need to touch

		int gemScoreForText = GameController.instance.GetGemScore ();

		gemScoreText.text = "" + gemScoreForText;
	}

	// Use this for initialization
	void Start ()
	{
		GemScore ();

	}

	// Update is called once per frame
	void Update ()
	{

	}

	void MakeInstance ()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	// pause the game

	public void PauseTheGame ()
	{
		if (BirdScript.instance != null)
		{
			if (BirdScript.instance.isAlive && youCanPause)
			{
				pausePanel.SetActive (true);

				Time.timeScale = 0f;

				//resumeGameButton.onClick.RemoveAllListeners ();
				//resumeGameButton.onClick.AddListener (() => ResumeGame ());
			}
		}
	}

	// resume game

	public void ResumeGame ()
	{
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}

	// restart the game

	public void RestartGame ()
	{
		SceneFader.instance.FadeIn (SceneManager.GetActiveScene ().name);
	}

	// go to menu Button

	public void GoToMenuButton ()
	{
		SceneFader.instance.FadeIn ("MainMenu");
	}

	public void ToMainMenu ()
	{
		SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
	}

	// working with score

	public void setScore (int score)
	{
		scoreText.text = "" + score;
	}

	// save me panel

	private int saveMeScore;
	private Vector3 spawnBirdHere;
	private bool noNeed;

	public void SaveMeMethod (int score, Vector3 spawnBirdPos)
	{

		saveMeScore = score;
		spawnBirdHere = spawnBirdPos;
		saveMePanel.SetActive (true);
		StartCoroutine (wait ());

	}

	public void SaveMe ()
	{
		noNeed = true;

		if (GameController.instance.GetGemScore () >= 2)
		{
			GameController.instance.SetGemScore (GameController.instance.GetGemScore () - 2);
			GemScore ();

			BirdScript.instance.transform.position = spawnBirdHere;
			BirdScript.instance.ResetPlayerState ();

			saveMePanel.SetActive (false);

			Time.timeScale = 0f;

			youCanPause = false;

			gameStarted = true;
		}
		else
		{
			StartCoroutine (showGameOverPanel ());
		}

	}

	IEnumerator wait ()
	{
		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (2.5f));
		saveMePanel.SetActive (false);

		if (!noNeed)
		{
			PlayerDied (saveMeScore);
		}

		noNeed = false;
	}

	IEnumerator showGameOverPanel ()
	{
		yield return new WaitForSeconds (1);
		saveMePanel.SetActive (false);

		PlayerDied (saveMeScore);
	}


	// player died
	//working fine, no need to touch

	public void PlayerDied (int score)
	{
		gameOverPanel.SetActive (true);

		endScore.text = "" + score;

		if (score > GameController.instance.GetHighScore ())
		{
			GameController.instance.SetHighScore (score);
		}

		bestScore.text = "" + GameController.instance.GetHighScore ();

		if (score < 50)
		{
			medalImage.sprite = medals[0];
		}
		else if (score >= 50 && score < 150)
		{
			medalImage.sprite = medals[1];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}

			if (GameController.instance.IsBirdsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockBirdsLevel ();
			}
		}
		else if (score >= 150 && score < 200)
		{
			medalImage.sprite = medals[2];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}

			if (GameController.instance.IsRedBirdUnlocked () == 0)
			{
				GameController.instance.UnlockRedBird ();
			}

			if (GameController.instance.IsBirdsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockBirdsLevel ();
			}

			if (GameController.instance.IsMountainsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockMountainsLevel ();
			}
		}
		else if (score >= 200 && score < 300)
		{
			medalImage.sprite = medals[2];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}

			if (GameController.instance.IsRedBirdUnlocked () == 0)
			{
				GameController.instance.UnlockRedBird ();
			}

			if (GameController.instance.IsBirdsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockBirdsLevel ();
			}

			if (GameController.instance.IsMountainsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockMountainsLevel ();
			}

			if (GameController.instance.IsLakeLevelUnlocked () == 0)
			{
				GameController.instance.UnlockLakeLevel ();
			}
		}
		else if (score >= 300 && score < 400)
		{
			medalImage.sprite = medals[2];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}

			if (GameController.instance.IsRedBirdUnlocked () == 0)
			{
				GameController.instance.UnlockRedBird ();
			}

			if (GameController.instance.IsBirdsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockBirdsLevel ();
			}

			if (GameController.instance.IsMountainsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockMountainsLevel ();
			}

			if (GameController.instance.IsLakeLevelUnlocked () == 0)
			{
				GameController.instance.UnlockLakeLevel ();
			}

			if (GameController.instance.IsSpringLevelUnlocked () == 0)
			{
				GameController.instance.UnlockSpringLevel ();
			}
		}
		else if (score >= 400 && score < 500)
		{
			medalImage.sprite = medals[2];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}

			if (GameController.instance.IsRedBirdUnlocked () == 0)
			{
				GameController.instance.UnlockRedBird ();
			}

			if (GameController.instance.IsBirdsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockBirdsLevel ();
			}

			if (GameController.instance.IsMountainsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockMountainsLevel ();
			}

			if (GameController.instance.IsLakeLevelUnlocked () == 0)
			{
				GameController.instance.UnlockLakeLevel ();
			}

			if (GameController.instance.IsSpringLevelUnlocked () == 0)
			{
				GameController.instance.UnlockSpringLevel ();
			}

			if (GameController.instance.IsFarmLevelUnlocked () == 0)
			{
				GameController.instance.UnlockFarmLevel ();
			}
		}
		else if (score >= 500 && score < 600)
		{
			medalImage.sprite = medals[2];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}

			if (GameController.instance.IsRedBirdUnlocked () == 0)
			{
				GameController.instance.UnlockRedBird ();
			}

			if (GameController.instance.IsBirdsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockBirdsLevel ();
			}

			if (GameController.instance.IsMountainsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockMountainsLevel ();
			}

			if (GameController.instance.IsLakeLevelUnlocked () == 0)
			{
				GameController.instance.UnlockLakeLevel ();
			}

			if (GameController.instance.IsSpringLevelUnlocked () == 0)
			{
				GameController.instance.UnlockSpringLevel ();
			}

			if (GameController.instance.IsFarmLevelUnlocked () == 0)
			{
				GameController.instance.UnlockFarmLevel ();
			}

			if (GameController.instance.IsWinterLevelUnlocked () == 0)
			{
				GameController.instance.UnlockWinterLevel ();
			}
		}
		else if (score >= 600 && score < 700)
		{
			medalImage.sprite = medals[2];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}

			if (GameController.instance.IsRedBirdUnlocked () == 0)
			{
				GameController.instance.UnlockRedBird ();
			}

			if (GameController.instance.IsBirdsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockBirdsLevel ();
			}

			if (GameController.instance.IsMountainsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockMountainsLevel ();
			}

			if (GameController.instance.IsLakeLevelUnlocked () == 0)
			{
				GameController.instance.UnlockLakeLevel ();
			}

			if (GameController.instance.IsSpringLevelUnlocked () == 0)
			{
				GameController.instance.UnlockSpringLevel ();
			}

			if (GameController.instance.IsFarmLevelUnlocked () == 0)
			{
				GameController.instance.UnlockFarmLevel ();
			}

			if (GameController.instance.IsWinterLevelUnlocked () == 0)
			{
				GameController.instance.UnlockWinterLevel ();
			}

			if (GameController.instance.IsEveningLevelUnlocked () == 0)
			{
				GameController.instance.UnlockEveningLevel ();
			}
		}
		else if (score >= 700 && score < 800)
		{
			medalImage.sprite = medals[2];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}

			if (GameController.instance.IsRedBirdUnlocked () == 0)
			{
				GameController.instance.UnlockRedBird ();
			}

			if (GameController.instance.IsBirdsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockBirdsLevel ();
			}

			if (GameController.instance.IsMountainsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockMountainsLevel ();
			}

			if (GameController.instance.IsLakeLevelUnlocked () == 0)
			{
				GameController.instance.UnlockLakeLevel ();
			}

			if (GameController.instance.IsSpringLevelUnlocked () == 0)
			{
				GameController.instance.UnlockSpringLevel ();
			}

			if (GameController.instance.IsFarmLevelUnlocked () == 0)
			{
				GameController.instance.UnlockFarmLevel ();
			}

			if (GameController.instance.IsWinterLevelUnlocked () == 0)
			{
				GameController.instance.UnlockWinterLevel ();
			}

			if (GameController.instance.IsEveningLevelUnlocked () == 0)
			{
				GameController.instance.UnlockEveningLevel ();
			}

			if (GameController.instance.IsDarkLevelUnlocked () == 0)
			{
				GameController.instance.UnlockDarkLevel ();
			}
		}
		else if (score >= 800)
		{
			medalImage.sprite = medals[2];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}

			if (GameController.instance.IsRedBirdUnlocked () == 0)
			{
				GameController.instance.UnlockRedBird ();
			}

			if (GameController.instance.IsBirdsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockBirdsLevel ();
			}

			if (GameController.instance.IsMountainsLevelUnlocked () == 0)
			{
				GameController.instance.UnlockMountainsLevel ();
			}

			if (GameController.instance.IsLakeLevelUnlocked () == 0)
			{
				GameController.instance.UnlockLakeLevel ();
			}

			if (GameController.instance.IsSpringLevelUnlocked () == 0)
			{
				GameController.instance.UnlockSpringLevel ();
			}

			if (GameController.instance.IsFarmLevelUnlocked () == 0)
			{
				GameController.instance.UnlockFarmLevel ();
			}

			if (GameController.instance.IsWinterLevelUnlocked () == 0)
			{
				GameController.instance.UnlockWinterLevel ();
			}

			if (GameController.instance.IsEveningLevelUnlocked () == 0)
			{
				GameController.instance.UnlockEveningLevel ();
			}

			if (GameController.instance.IsDarkLevelUnlocked () == 0)
			{
				GameController.instance.UnlockDarkLevel ();
			}

			if (GameController.instance.IsRainyLevelUnlocked () == 0)
			{
				GameController.instance.UnlockRainyLevel ();
			}
		}
	}
}