﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	void Update () {
		if (SceneManager.GetActiveScene ().name == "SceneName") {
			Destroy (gameObject);
		}
	}
}
