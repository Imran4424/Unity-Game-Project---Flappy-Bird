using System.Collections;
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

	public bool isSaveMeUsed;

	void Awake ()
	{
		MakeInstance ();
		isSaveMeUsed = false;
		birds[GameController.instance.GetSelectedBird ()].SetActive (true);

		Time.timeScale = 1f;

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
			if (BirdScript.instance.isAlive)
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
		Time.timeScale = 0f;
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
		isSaveMeUsed = true;

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

			Time.timeScale = 0.000001f;

			StartCoroutine (waitForPlay ());
		}
		else
		{
			StartCoroutine (showGameOverPanel ());
		}

	}

	IEnumerator wait ()
	{
		yield return new WaitForSeconds (3);
		saveMePanel.SetActive (false);

		if (!noNeed)
		{
			PlayerDied (saveMeScore);

		}
	}

	IEnumerator showGameOverPanel ()
	{
		yield return new WaitForSeconds (1);
		saveMePanel.SetActive (false);

		PlayerDied (saveMeScore);
	}

	IEnumerator waitForPlay ()
	{
		float pauseEndTime = Time.realtimeSinceStartup + 3f;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}

		Time.timeScale = 1f;

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

		if (score <= 50)
		{
			medalImage.sprite = medals[0];
		}
		else if (score > 50 && score <= 150)
		{
			medalImage.sprite = medals[1];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}
		}
		else if (score > 150 && score <= 200)
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
		}
		else if (score > 200 && score <= 350)
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

			if (GameController.instance.IsForestLevelUnlocked () == 0)
			{
				GameController.instance.UnlockForestLevel ();
			}
		}
		else if (score > 350 && score <= 500)
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

			if (GameController.instance.IsForestLevelUnlocked () == 0)
			{
				GameController.instance.UnlockForestLevel ();
			}

			if (GameController.instance.IsEveningLevelUnlocked () == 0)
			{
				GameController.instance.UnlockEveningLevel ();
			}
		}
		else if (score > 500)
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

			if (GameController.instance.IsForestLevelUnlocked () == 0)
			{
				GameController.instance.UnlockForestLevel ();
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
	}
}