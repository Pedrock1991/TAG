using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupLocalizationManager : MonoBehaviour {

	// Use this for initialization
	private IEnumerator Start () 
	{
		while (!LocalizationManager.instance.GetIsReady ()) 
		{
			yield return null;
		}

		SceneManager.LoadScene ("MainMenu");
	}

}