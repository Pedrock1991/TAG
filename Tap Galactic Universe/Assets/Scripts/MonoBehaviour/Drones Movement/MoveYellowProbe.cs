using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYellowProbe : MonoBehaviour {

	public GameObject yellowClick;
	public YellowClick click;

	public Vector2 upPosition;
	public Vector2 spacePosition;
	public Vector2 originPosition;

	public float speed;
	float step;
	public int move = 1;

	void Start () {
		step = speed * Time.deltaTime;
		yellowClick = GameObject.Find ("YellowClick");
		click = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));
		click.probes++;

		if (click.newPlanet == true) {
			click.probes--;
			Destroy (transform.gameObject);
		}

		upPosition = new Vector2 (Random.Range (0, 2f), Random.Range (0, 1f));

		spacePosition = new Vector2 (Random.Range (4f, 10f),4f);

		originPosition = new Vector2 (0, 0);
	}

	void Update () {
		if (move < 100) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), upPosition, step);
			move++;
		}
		if (move == 100) {
			SoundManager.PlaySound ("yellowMove");
		}
		if (move >= 100 && move < 2000) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), spacePosition, step);
			move++;
		}
		if (move >= 2000 && move < 2100) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), originPosition, step);
			move++;
		}
		if (move == 2100) {
			click.count ();
			click.probes--;
			Destroy (transform.gameObject);
		}
	}
}
