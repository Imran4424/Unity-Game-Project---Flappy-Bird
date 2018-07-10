using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[SerializeField]
	private Text scoreText, endScore, bestScore, gemScoreText;

	[SerializeField]
	private Button pauseGameButton, resumeGameButton;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel, saveMePanel;

	[SerializeField]
	private GameObject[] birds;

	[SerializeField]
	private Sprite[] medals;

	[SerializeField]
	private Image medalImage;

	void Awake()
	{
		MakeInstance();
		Time.timeScale = 1f;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void MakeInstance()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	// pause the game

	public void PauseTheGame()
	{
		if (BirdScript.instance != null)
		{
			if (BirdScript.instance.isAlive)
			{
				pausePanel.SetActive(true);

				Time.timeScale = 0f;

				resumeGameButton.onClick.RemoveAllListeners();
				resumeGameButton.onClick.AddListener(() => ResumeGame());
			}
		}
	}

	// resume game

	public void ResumeGame()
	{

	}

	// go to menu Button

	public void GoToMenuButton()
	{
		
	}
}


