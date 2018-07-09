﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour 
{

	public static MenuController instance;

	[SerializeField]
	private GameObject[] birds;

	[SerializeField]
	private GameObject[] gameLevels;

	private bool isGreenBirdUnlocked;
	private bool isRedBirdUnlocked;
	private bool isDarkLevelUnlocked;

	void Awake()
	{
		MakeInstance();
	}

	// Use this for initialization
	void Start () 
	{
		CheckIfBirdsAreUnlocked();
		CheckIfLevelsAreUnlocked();
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

	// checking if the the birds are unlocked or not

	void CheckIfBirdsAreUnlocked()
	{
		if (GameController.instance.IsGreenBirdUnlocked() == 1)
		{
			isGreenBirdUnlocked = true;
		}

		if (GameController.instance.IsRedBirdUnlocked() == 1)
		{
			isRedBirdUnlocked = true;
		}
	}

	// checking if levels are unlocked or not

	void CheckIfLevelsAreUnlocked()
	{
		if (GameController.instance.IsDarkLevelUnlocked() == 1)
		{
			isDarkLevelUnlocked = true;
		}
	}
}
