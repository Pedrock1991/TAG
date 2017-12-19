using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSMovement : MonoBehaviour {

	public Vector2 upPosition;
	public Vector2 downPosition;
	public Vector2 originPosition;

	public float speed = 0.5f;
	float step;
	public int move = 1;

	// Use this for initialization
	void Start () {
		step = speed * Time.deltaTime;
		upPosition = new Vector2 (Random.Range (1, 1.2f), Random.Range (0.5f, 0.7f));

		downPosition = new Vector2 (Random.Range (1, 0.8f), Random.Range (0.5f, 0.3f));

		originPosition = new Vector2 (1f, 0.5f);

	}
	
	// Update is called once per frame
	void Update () {
		if (move < 500) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), upPosition, step);
			move++;
		}
		if (move >= 500 && move < 1000) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), originPosition, step);
			move++;
		}
		if (move >= 1000 && move < 1500) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), downPosition, step);
			move++;
		}
		if (move >= 1500 && move < 2000) {
			transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), originPosition, step);
			move++;
		}
		if (move == 2000) {
			upPosition = new Vector2 (Random.Range (1, 1.2f), Random.Range (0.5f, 0.7f));
			downPosition = new Vector2 (Random.Range (1, 0.8f), Random.Range (0.5f, 0.3f));
			move = 1;
		}
	}
}
