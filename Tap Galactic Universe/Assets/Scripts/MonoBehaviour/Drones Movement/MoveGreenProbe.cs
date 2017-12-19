using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGreenProbe : MonoBehaviour {

	public GameObject greenClick;
	public GreenClick click;

	public Vector2 upPosition;
	public Vector2 downPosition;
	public Vector2 originPosition;

	public float speed;
	float step;
	public int move = 1;

	void Start () {
		step = speed * Time.deltaTime;
		greenClick = GameObject.Find ("GreenClick");
		click = (GreenClick)greenClick.GetComponent (typeof(GreenClick));
		click.probes++;

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
			SoundManager.PlaySound ("greenMove");
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
