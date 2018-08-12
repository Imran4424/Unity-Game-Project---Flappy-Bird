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
	private bool isEveningLevelUnlocked;
	private bool isDarkLevelUnlocked;

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
		if (GameController.instance.IsForestLevelUnlocked () == 1)
		{
			isForestLevelUnlocked = true;
		}

		if (GameController.instance.IsEveningLevelUnlocked () == 1)
		{
			isEveningLevelUnlocked = true;
		}

		if (GameController.instance.IsDarkLevelUnlocked () == 1)
		{
			isDarkLevelUnlocked = true;
		}
	}

	// play game

	public void PlayGame ()
	{
		if (GameController.instance.GetSelectedLevel () == 0)
		{
			SceneFader.instance.FadeIn ("GamePlay");
		}
		else if (GameController.instance.GetSelectedLevel () == 1)
		{
			SceneFader.instance.FadeIn ("GamePlay Forest");
		}
		else if (GameController.instance.GetSelectedLevel () == 2)
		{
			SceneFader.instance.FadeIn ("GamePlay Evening");
		}
		else if (GameController.instance.GetSelectedLevel () == 3)
		{
			SceneFader.instance.FadeIn ("GamePlay Dark");
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
			//Debug.Log ("i am in green bird");

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
			if (isForestLevelUnlocked)
			{
				gameLevels[0].SetActive (false);

				GameController.instance.SetSelectedLevel (1);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 1)
		{
			if (isEveningLevelUnlocked)
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
			if (isDarkLevelUnlocked)
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
			gameLevels[3].SetActive (false);

			GameController.instance.SetSelectedLevel (0);
			gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
		}
	}

}