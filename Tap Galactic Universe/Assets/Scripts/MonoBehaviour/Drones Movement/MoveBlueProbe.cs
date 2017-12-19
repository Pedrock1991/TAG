using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlueProbe : MonoBehaviour {

	public GameObject blueClick;
	public BlueClick click;

	public YellowClick yellow;
	public GameObject yellowClick;

	public Vector2 upPosition;
	public Vector2 downPosition;
	public Vector2 originPosition;

	public float speed;
	float step;
	public int move = 1;

	void Start () {
		yellowClick = GameObject.Find ("YellowClick");
		yellow = (YellowClick)yellowClick.GetComponent (typeof(YellowClick));

		step = speed * Time.deltaTime;
		blueClick = GameObject.Find ("BlueClick");
		click = (BlueClick)blueClick.GetComponent (typeof(BlueClick));
		click.probes++;

		if (click.discoveryFound >= (yellow.planetFound*10)) {
			click.probes--;
			Destroy (transform.gameObject);
		}

		upPosition = new Vector2 (Random.Range (0, 2f), Random.Range (0, 1f));

		downPosition = new Vector2 (Random.Range (-4f, -10f),-4f);

		originPosition = new Vector2 (0, 0);
	}

	void Update () {
		if (move < 100) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), upPosition, step);
			move++;
		}
		if (move == 100) {
			SoundManager.PlaySound ("blueMove");
		}
		if (move >= 100 && move < 200) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), downPosition, step);
			move++;
		}
		if (move >= 200 && move < 300) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), originPosition, step);
			move++;
		}
		if (move == 300) {
			click.count ();
			click.probes--;
			Destroy (transform.gameObject);
		}
	}
}
