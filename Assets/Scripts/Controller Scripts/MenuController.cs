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

	void Awake ()
	{
		MakeInstance ();
	}

	// Use this for initialization
	void Start ()
	{
		birds[GameController.instance.GetSelectedBird ()].SetActive (true);

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
		if (GameController.instance.IsDarkLevelUnlocked () == 1)
		{
			isDarkLevelUnlocked = true;
		}
	}

	// changing the birds

	public void ChangeBirds ()
	{
		if (GameController.instance.GetSelectedBird () == 0)
		{
			if (isGreenBirdUnlocked)
			{
				birds[0].SetActive (false);

				GameController.instance.SetSelectedBird (1);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
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
	}

	// changing the levels

	public void ChangeLevels ()
	{
		if (GameController.instance.GetSelectedLevel () == 0)
		{
			if (isDarkLevelUnlocked)
			{
				gameLevels[0].SetActive (false);

				GameController.instance.SetSelectedLevel (1);
				gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
			}
		}
		else if (GameController.instance.GetSelectedLevel () == 1)
		{
			gameLevels[1].SetActive (false);

			GameController.instance.SetSelectedLevel (0);
			gameLevels[GameController.instance.GetSelectedLevel ()].SetActive (true);
		}
	}

}