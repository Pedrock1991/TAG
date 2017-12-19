using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplayManager : MonoBehaviour {

	public Image[] MaleLives = new Image[5];
	public Image[] FemaleLives = new Image[5];
	public Image[] X = new Image[5];

	void Update () {
		ShowLives ();
	}

	void ShowLives () {
		if (GameManager.instance.GetVerifyLives ()) {
			int numberOfLostLives = 5 - GameManager.instance.GetLives ();
			Color color;

			for (int i = 0; i < 5; i++) {
				if (GameManager.instance.GetGenreMale ()) {
					color = FemaleLives [i].color;
					color.a = 0;
					FemaleLives [i].color = color;
					color = X [i].color;
					color.a = 0;
					X [i].color = color;

				}
				if (GameManager.instance.GetGenreFemale ()) {
					color = MaleLives [i].color;
					color.a = 0;
					MaleLives [i].color = color;
					color = X [i].color;
					color.a = 0;
					X [i].color = color;
				}
			}
			for (int i = 0; i < numberOfLostLives; i++) {
				color = X [i].color;
				color.a = 1;
				X [i].color = color;
			}
			GameManager.instance.SetVerifyLives (false);
		}
	}
}
