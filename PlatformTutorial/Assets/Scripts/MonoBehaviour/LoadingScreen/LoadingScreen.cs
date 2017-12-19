using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

	public GameObject Male;
	public GameObject Female;

	public bool loadScene = false;

	[SerializeField]
	private string scene;
	[SerializeField]
	private Text loadingText;

	// Use this for initialization
	void Start () {
		if (GameManager.instance.GetGenreMale ()) {
			Male.SetActive (true);
			Female.SetActive (false);
		}
		if (GameManager.instance.GetGenreFemale ()) {
			Male.SetActive (false);
			Female.SetActive (true);
		}
		Load (GameManager.instance.GetLoadingScene ());
	}
	
	// Update is called once per frame
	void Update () {
		if (loadScene == true) {
			loadingText.color = new Color (loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong (Time.time, 1));
		}
	}

	void Load (string loadSceneName) {
		scene = loadSceneName;
		loadScene = true;
		StartCoroutine (LoadNewScene ());
	}

	IEnumerator LoadNewScene () {
		yield return new WaitForSeconds (3);

		AsyncOperation async = SceneManager.LoadSceneAsync (scene);

		while (!async.isDone) {
			yield return null;
		}
	}
}
