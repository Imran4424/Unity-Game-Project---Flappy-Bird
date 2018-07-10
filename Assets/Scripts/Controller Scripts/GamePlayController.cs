using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayController : MonoBehaviour {

	public static GamePlayController instance;

	[SerializeField]
	private Text scoreText, endScore, bestScore, gemScoreText;

	[SerializeField]
	private Button pauseGameButton, restartGameButton;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
