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

	private bool isRedBirdUnlocked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
