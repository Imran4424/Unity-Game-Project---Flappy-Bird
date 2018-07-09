using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

	public static GameController instance;

	public const string High_Score = "High Score";
	public const string Selected_Bird = "Selected Bird";
	public const string Green_Bird = "Green Bird";
	public const string Red_Bird = "Red Bird";

	public const string Dark_Level = "Dark Level";

	void Awake ()
	{
		MakeSingleton ();
		IsTheGameStartedForTheFirstTime ();
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
			PlayerPrefs.SetInt (High_Score, 0);
			PlayerPrefs.SetInt (Selected_Bird, 0);
			PlayerPrefs.SetInt (Green_Bird, 0);
			PlayerPrefs.SetInt (Red_Bird, 0);
			PlayerPrefs.SetInt (Dark_Level, 0);

			PlayerPrefs.SetInt ("IsTheGameStartedForTheFirstTime", 0);
		}
	}

	//working with high score

	public void SetHighScore (int score)
	{
		PlayerPrefs.SetInt (High_Score, score);
	}

	public int GetHighScore ()
	{
		return PlayerPrefs.GetInt (High_Score);
	}

	// working with selected birds

	public void SetSelectedBird (int selectedBird)
	{
		PlayerPrefs.SetInt (Selected_Bird, selectedBird);
	}

	public int GetSelectedBird ()
	{
		return PlayerPrefs.GetInt (Selected_Bird);
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

	// Unlocking Dark Level

	
}