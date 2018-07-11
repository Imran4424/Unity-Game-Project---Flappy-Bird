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

	void Awake ()
	{
		MakeInstance ();
		birds[GameController.instance.GetSelectedBird ()].SetActive (true);

		Time.timeScale = 1f;
	}

	// Use this for initialization
	void Start ()
	{
		gemScoreText.text = "" + GameController.instance.GetGemScore ();
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

	public void SaveMeMethod(int score)
	{
		saveMeScore = score;
		saveMePanel.SetActive(true);
		StartCoroutine(wait());
		saveMePanel.SetActive(false);
	}

	public void SaveMe()
	{

	}

	IEnumerator wait()
	{
		
		yield return new WaitForSeconds(3);
	}

	// player died

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
		else if (score > 50 && score < 200)
		{
			medalImage.sprite = medals[1];

			if (GameController.instance.IsGreenBirdUnlocked () == 0)
			{
				GameController.instance.UnlockGreenBird ();
			}
		}
		else if (score > 200 && score < 500)
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
		else
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

			if (GameController.instance.IsDarkLevelUnlocked () == 0)
			{
				GameController.instance.UnlockDarkLevel ();
			}
		}
	}
}