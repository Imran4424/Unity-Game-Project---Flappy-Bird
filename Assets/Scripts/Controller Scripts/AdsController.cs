using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsController : MonoBehaviour 
{
	public static AdsController instance;

	void Awake()
	{
		MakeSingleton();
	}

	// Use this for initialization
	void Start () 
	{
		
	}

	void MakeSingleton()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(instance);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
