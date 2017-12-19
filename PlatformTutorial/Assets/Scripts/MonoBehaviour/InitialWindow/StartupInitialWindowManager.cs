using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupInitialWindowManager : MonoBehaviour {

	// Use this for initialization
	private IEnumerator Start () 
	{
		while (!InitialWindowManager.instance.GetIsReady ()) 
		{
			yield return null;
		}

		GameManager.instance.SetLoadingScene ("PlanetMenu");
		SceneManager.LoadScene ("LoadingScreen");
	}
}
