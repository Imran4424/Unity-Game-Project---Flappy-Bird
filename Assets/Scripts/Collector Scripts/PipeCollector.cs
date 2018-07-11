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

	void MakeInstance()
	{
		
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