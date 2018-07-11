using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour
{

	public static PipeCollector instance;

	private GameObject[] pipeHolders;
	private float distance = 5f;
	private float lastPipeX;
	private float pipeMin = -1.5f;
	private float pipeMax = 2.4f;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake ()
	{
		MakeInstance ();

		pipeHolders = GameObject.FindGameObjectsWithTag ("PipeHolder");

		for (int i = 0; i < pipeHolders.Length; i++)
		{
			Vector3 temp = pipeHolders[i].transform.position;

			temp.y = Random.Range (pipeMin, pipeMax);

			pipeHolders[i].transform.position = temp;
		}

		lastPipeX = pipeHolders[0].transform.position.x;

		for (int i = 1; i < pipeHolders.Length; i++)
		{
			if (lastPipeX < pipeHolders[i].transform.position.x)
			{
				lastPipeX = pipeHolders[i].transform.position.x;
				//Debug.Log (lastPipeX);
			}
		}
	}

	/*
		must have start function in your code unless it will give problem
	*/

	void Start ()
	{

	}

	/*
		must have update function in your code unless it will give problem
	*/

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

	public void ManipulatingDistance (int score)
	{
		if (score >= 50 && score <= 100)
		{
			distance = 4.75f;
		}
		else if (score >= 100 && score <= 150)
		{
			distance = 4.5f;
		}
		else if (score >= 150 && score <= 200)
		{
			distance = 4.25f;
		}
		else if (score >= 200 && score <= 250)
		{
			distance = 4f;
		}
		else if (score >= 250 && score <= 300)
		{
			distance = 3.75f;
		}
		else if (score >= 350 && score <= 400)
		{
			distance = 3.5f;
		}
		else if (score >= 400 && score <= 550)
		{
			distance = 3.25f;
		}
		else if (score <= 550)
		{
			distance = 3f;
		}
	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "PipeHolder")
		{
			Vector3 temp = target.transform.position;

			temp.x = lastPipeX + distance;
			temp.y = Random.Range (pipeMin, pipeMax);

			target.transform.position = temp;

			//Debug.Log (lastPipeX);

			lastPipeX = temp.x;
			//Debug.Log (lastPipeX);
		}
	}
}