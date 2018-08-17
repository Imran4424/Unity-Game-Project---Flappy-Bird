using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutController : MonoBehaviour 
{

	public void BackToMainMenu()
	{
		SceneFader.instance.FadeIn("MainMenu");
	}
}
