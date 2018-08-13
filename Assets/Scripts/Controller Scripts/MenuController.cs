using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

	public static MenuController instance;

	[SerializeField]
	private GameObject[] birds;

	[SerializeField]
	private GameObject[] gameLevels;

	private bool isGreenBirdUnlocked;
	private bool isRedBirdUnlocked;

	private bool isBirdsLevelUnlocked;
	private bool isMountainsLevelUnlocked;
	private bool isLakeLevelUnlocked;
	private bool isSpringLevelUnlocked;
	private bool isFarmLevelUnlocked;
	private bool isWinterLevelUnlocked;
	private bool isEveningLevelUnlocked;
	private bool isDarkLevelUnlocked;
	private bool isRainyLevelUnlocked;

	// gem button and gem text

	[SerializeField]
	private Button gemButton;

	[SerializeField]
	private Text gemScoreText;

	void Awake ()
	{
		MakeInstance ();

		Time.timeScale = 1f;
	}

	// Use this for initialization
	void Start ()
	{
		birds[GameController.instance.GetSelectedBird ()].SetActive (true);
		gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);

		gemScoreText.text = "" + GameController.instance.GetGemScore ();

		CheckIfBirdsAreUnlocked ();
		CheckIfLevelsAreUnlocked ();

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

	// checking if the the birds are unlocked or not

	void CheckIfBirdsAreUnlocked ()
	{
		if (GameController.instance.IsGreenBirdUnlocked () == 1)
		{
			isGreenBirdUnlocked = true;
		}

		if (GameController.instance.IsRedBirdUnlocked () == 1)
		{
			isRedBirdUnlocked = true;
		}
	}

	// checking if levels are unlocked or not

	void CheckIfLevelsAreUnlocked ()
	{
		// Birds

		if (GameController.instance.IsBirdsLevelUnlocked () == 1)
		{
			isBirdsLevelUnlocked = true;
		}

		// Mountains

		if (GameController.instance.IsMountainsLevelUnlocked () == 1)
		{
			isMountainsLevelUnlocked = true;
		}

		// Lake

		if (GameController.instance.IsLakeLevelUnlocked () == 1)
		{
			isLakeLevelUnlocked = true;
		}

		// Spring

		if (GameController.instance.IsSpringLevelUnlocked () == 1)
		{
			isSpringLevelUnlocked = true;
		}

		// Farm

		if (GameController.instance.IsFarmLevelUnlocked () == 1)
		{
			isFarmLevelUnlocked = true;
		}

		// Winter

		if (GameController.instance.IsWinterLevelUnlocked () == 1)
		{
			isWinterLevelUnlocked = true;
		}

		// Evening

		if (GameController.instance.IsEveningLevelUnlocked () == 1)
		{
			isEveningLevelUnlocked = true;
		}

		// Dark

		if (GameController.instance.IsDarkLevelUnlocked () == 1)
		{
			isDarkLevelUnlocked = true;
		}

		// Rainy

		if (GameController.instance.IsRainyLevelUnlocked () == 1)
		{
			isRainyLevelUnlocked = true;
		}
	}

	// play game

	public void PlayGame ()
	{
		if (GameController.instance.GetSelectedLevel () == 0)
		{
			SceneFader.instance.FadeIn ("GamePlay Forest");
		}
		else if (GameController.instance.GetSelectedLevel () == 1)
		{
			SceneFader.instance.FadeIn ("GamePlay Birds");
		}
		else if (GameController.instance.GetSelectedLevel () == 2)
		{
			SceneFader.instance.FadeIn ("GamePlay Mountains");
		}
		else if (GameController.instance.GetSelectedLevel () == 3)
		{
			SceneFader.instance.FadeIn ("GamePlay Lake");
		}
		else if (GameController.instance.GetSelectedLevel () == 4)
		{
			SceneFader.instance.FadeIn ("GamePlay Spring");
		}
		else if (GameController.instance.GetSelectedLevel () == 5)
		{
			SceneFader.instance.FadeIn ("GamePlay Farm");
		}
		else if (GameController.instance.GetSelectedLevel () == 6)
		{
			SceneFader.instance.FadeIn ("GamePlay Winter");
		}
		else if (GameController.instance.GetSelectedLevel () == 7)
		{
			SceneFader.instance.FadeIn ("GamePlay Evening");
		}
		else if (GameController.instance.GetSelectedLevel () == 8)
		{
			SceneFader.instance.FadeIn ("GamePlay Dark");
		}
		else if (GameController.instance.GetSelectedLevel () == 9)
		{
			SceneFader.instance.FadeIn ("GamePlay Rainy");
		}

	}

	// Quit The Game

	public void QuitTheGame ()
	{
		Application.Quit ();
	}

	// about menu

	public void GoToAbout ()
	{
		SceneFader.instance.FadeIn ("About");
	}

	// changing the birds

	public void ChangeBirds ()
	{
		//Debug.Log (GameController.instance.GetSelectedBird ());

		if (GameController.instance.GetSelectedBird () == 0)
		{

			if (isGreenBirdUnlocked)
			{
				birds[0].SetActive (false);

				GameController.instance.SetSelectedBird (1);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
			}

		}
		else if (GameController.instance.GetSelectedBird () == 1)
		{

			if (isRedBirdUnlocked)
			{
				birds[1].SetActive (false);

				GameController.instance.SetSelectedBird (2);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
			}
			else
			{
				birds[1].SetActive (false);

				GameController.instance.SetSelectedBird (0);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedBird () == 2)
		{
			birds[2].SetActive (false);

			GameController.instance.SetSelectedBird (0);
			birds[GameController.instance.GetSelectedBird ()].SetActive (true);
		}
	}

	// changing the levels

	public void ChangeLevels ()
	{
		if (GameController.instance.GetSelectedLevel () == 0)
		{
			if (isBirdsLevelUnlocked)
			{
				gameLevels[0].SetActive (false);

				GameController.instance.SetSelectedLevel (1);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 1)
		{
			if (isMountainsLevelUnlocked)
			{
				gameLevels[1].SetActive (false);

				GameController.instance.SetSelectedLevel (2);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
			else
			{
				gameLevels[1].SetActive (false);

				GameController.instance.SetSelectedLevel (0);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 2)
		{
			if (isLakeLevelUnlocked)
			{
				gameLevels[2].SetActive (false);

				GameController.instance.SetSelectedLevel (3);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
			else
			{
				gameLevels[2].SetActive (false);

				GameController.instance.SetSelectedLevel (0);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 3)
		{
			if (isSpringLevelUnlocked)
			{
				gameLevels[3].SetActive (false);

				GameController.instance.SetSelectedLevel (4);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
			else
			{
				gameLevels[3].SetActive (false);

				GameController.instance.SetSelectedLevel (0);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 4)
		{
			if (isFarmLevelUnlocked)
			{
				gameLevels[4].SetActive (false);

				GameController.instance.SetSelectedLevel (5);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
			else
			{
				gameLevels[4].SetActive (false);

				GameController.instance.SetSelectedLevel (0);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 5)
		{
			if (isWinterLevelUnlocked)
			{
				gameLevels[5].SetActive (false);

				GameController.instance.SetSelectedLevel (6);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
			else
			{
				gameLevels[5].SetActive (false);

				GameController.instance.SetSelectedLevel (0);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 6)
		{
			if (isEveningLevelUnlocked)
			{
				gameLevels[6].SetActive (false);

				GameController.instance.SetSelectedLevel (7);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
			else
			{
				gameLevels[6].SetActive (false);

				GameController.instance.SetSelectedLevel (0);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 7)
		{
			if (isDarkLevelUnlocked)
			{
				gameLevels[7].SetActive (false);

				GameController.instance.SetSelectedLevel (8);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
			else
			{
				gameLevels[7].SetActive (false);

				GameController.instance.SetSelectedLevel (0);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 3)
		{
			if (isSpringLevelUnlocked)
			{
				gameLevels[3].SetActive (false);

				GameController.instance.SetSelectedLevel (4);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
			else
			{
				gameLevels[3].SetActive (false);

				GameController.instance.SetSelectedLevel (0);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
	}

}