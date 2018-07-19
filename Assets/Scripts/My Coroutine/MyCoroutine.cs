using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCoroutine : MonoBehaviour {

	public static IEnumerator WaitForRealSeconds(float time)
	{
		float starts = Time.realtimeSinceStartup;

		while (Time.realtimeSinceStartup < (starts + time))
		{
			yield return null;
		}
		yield return null;
	}
}
