﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

	public static SceneFader instance;

	[SerializeField]
	private GameObject fadeCanvas;

	[SerializeField]
	private Animator fadeAnim;

	void Awake ()
	{
		MakeSingleton ();
	}

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	// making singleton

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

	//working with animations

	public void FadeIn (string levelName)
	{
		StartCoroutine (FadeInAnimation (levelName));
	}

	public void FadeOut ()
	{
		StartCoroutine (FadeOutAnimation ());
	}

	IEnumerator FadeInAnimation (string levelName)
	{
		fadeCanvas.SetActive (true);
		fadeAnim.Play ("FadeIn");

		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (0.5f));

		SceneManager.LoadScene (levelName, LoadSceneMode.Single);
		FadeOut ();
	}

	IEnumerator FadeOutAnimation ()
	{
		fadeAnim.Play ("FadeOut");
		yield return StartCoroutine (MyCoroutine.WaitForRealSeconds (0.5f));
		fadeCanvas.SetActive (false);
	}
}