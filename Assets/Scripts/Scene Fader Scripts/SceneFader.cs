﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

	public static SceneFader instance;

	[SerializeField]
	private GameObject fadeCanvas;

	[SerializeField]
	private Animator fadeAnim;


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// making singleton

	void MakeSingleton()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	IEnumerator FadeInAnimation(string levelname)
	{
		fadeCanvas.SetActive(true);
		fadeAnim.Play("FadeIn");
		
		yield return new WaitForSeconds(.7f);

		SceneManager.LoadScene(levelname,LoadSceneMode.Single);
	}
}
