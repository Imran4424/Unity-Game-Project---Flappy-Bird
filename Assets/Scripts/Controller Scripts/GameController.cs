using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	public static GameController instance;

	public const string High_Score = "High Score";
	public const string Gem_Score = "Gem Score";
	public const string Selected_Bird = "Selected Bird";
	public const string Green_Bird = "Green Bird";
	public const string Red_Bird = "Red Bird";

	public const string Selected_Level = "Selected Level";

	/*
		Level Names
	*/

	public const string Forest_Level = "Forest Level";
	public const string Birds_Level = "Birds Level";
	public const string Mountains_Level = "Mountains Level";
	public const string Lake_Level = "Lake Level";
	public const string Spring_Level = "Spring Level";
	public const string Farm_Level = "Farm Level";
	public const string Winter_Level = "Winter Level";
	public const string Evening_Level = "Evening Level";
	public const string Dark_Level = "Dark Level";
	public const string Rainy_Level = "Rainy Level";

	void Awake ()
	{
		MakeSingleton ();
		IsTheGameStartedForTheFirstTime ();

		UnlockDarkLevel();
		UnlockEveningLevel();
		UnlockForestLevel();
		UnlockRedBird();
		UnlockRedBird();
	}

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

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

	/*
	 The Game started for first time or not, this functon will check that 
	*/
	void IsTheGameStartedForTheFirstTime ()
	{
		if (!PlayerPrefs.HasKey ("IsTheGameStartedForTheFirstTime"))
		{
			//Debug.Log("I am here");

			PlayerPrefs.SetInt (High_Score, 0);
			PlayerPrefs.SetInt (Gem_Score, 10);
			PlayerPrefs.SetInt (Selected_Bird, 0);
			PlayerPrefs.SetInt (Green_Bird, 0);
			PlayerPrefs.SetInt (Red_Bird, 0);

			PlayerPrefs.SetInt (Birds_Level, 0);
			PlayerPrefs.SetInt (Mountains_Level, 0);
			PlayerPrefs.SetInt (Lake_Level, 0);
			PlayerPrefs.SetInt (Spring_Level, 0);
			PlayerPrefs.SetInt (Farm_Level, 0);
			PlayerPrefs.SetInt (Winter_Level, 0);
			PlayerPrefs.SetInt (Evening_Level, 0);
			PlayerPrefs.SetInt (Dark_Level, 0);
			PlayerPrefs.SetInt (Rainy_Level, 0);

			PlayerPrefs.SetInt ("IsTheGameStartedForTheFirstTime", 0);
		}
	}

	//  working with high score

	public void SetHighScore (int score)
	{
		PlayerPrefs.SetInt (High_Score, score);
	}

	public int GetHighScore ()
	{
		return PlayerPrefs.GetInt (High_Score);
	}

	// working with gem score

	public void SetGemScore (int gemScore)
	{
		PlayerPrefs.SetInt (Gem_Score, gemScore);
	}

	public int GetGemScore ()
	{
		return PlayerPrefs.GetInt (Gem_Score);
	}

	// working with selected birds

	public void SetSelectedBird (int selectedBird)
	{
		//Debug.Log("i am green selected bird");

		PlayerPrefs.SetInt (Selected_Bird, selectedBird);
	}

	public int GetSelectedBird ()
	{
		return PlayerPrefs.GetInt (Selected_Bird);
	}

	//  working with levels

	public void SetSelectedLevel (int SelectedLevel)
	{
		PlayerPrefs.SetInt (Selected_Level, SelectedLevel);
	}

	public int GetSelectedLevel ()
	{
		return PlayerPrefs.GetInt (Selected_Level);
	}

	// Unlocking green bird

	public void UnlockGreenBird ()
	{
		PlayerPrefs.SetInt (Green_Bird, 1);
	}

	public int IsGreenBirdUnlocked ()
	{
		return PlayerPrefs.GetInt (Green_Bird);
	}

	// Unlocking Red bird

	public void UnlockRedBird ()
	{
		PlayerPrefs.SetInt (Red_Bird, 1);
	}

	public int IsRedBirdUnlocked ()
	{
		return PlayerPrefs.GetInt (Red_Bird);
	}

	// Unlocking Forest Level

	public void UnlockForestLevel ()
	{
		PlayerPrefs.SetInt (Dark_Level, 1);
	}

	public int IsForestLevelUnlocked ()
	{
		return PlayerPrefs.GetInt (Dark_Level);
	}

	// Unlocking Evening Level

	public void UnlockEveningLevel ()
	{
		PlayerPrefs.SetInt (Dark_Level, 1);
	}

	public int IsEveningLevelUnlocked ()
	{
		return PlayerPrefs.GetInt (Dark_Level);
	}

	// Unlocking Dark Level

	public void UnlockDarkLevel ()
	{
		PlayerPrefs.SetInt (Dark_Level, 1);
	}

	public int IsDarkLevelUnlocked ()
	{
		return PlayerPrefs.GetInt (Dark_Level);
	}
}