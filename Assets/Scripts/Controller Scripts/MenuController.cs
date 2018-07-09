using System.Collections;
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

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

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
}
