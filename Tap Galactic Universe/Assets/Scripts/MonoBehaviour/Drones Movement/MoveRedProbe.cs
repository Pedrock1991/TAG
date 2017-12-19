using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRedProbe : MonoBehaviour {

	public GameObject redClick;
	public GameObject asteroid;
	public RedClick click;

	public int move = 1;

	GameObject planet;
	public Transform center;
	public Vector3 axis = new Vector3(-3.0f, 7.0f, -0.1f);
	public Vector3 desiredPosition;
	public float radius = 2.0f;
	public float radiusSpeed = 0.5f;
	public float rotationSpeed = 80.0f;

	void Start () {

		redClick = GameObject.Find ("RedClick");
		asteroid = GameObject.Find ("Asteroid(Clone)");

		click = (RedClick)redClick.GetComponent (typeof(RedClick));

		click.probes++;

		planet = GameObject.Find ("Planet");
		radius = Random.Range (1.0f, 1.5f);
		center = planet.transform;
		if (asteroid == null && click.life <= 0) {
			click.probes--;
			Destroy (transform.gameObject);
		}
		transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);


	}
	
	// Update is called once per frame
	void Update () {
		if (move < 100) {
			transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
			desiredPosition = (transform.position - center.position).normalized * radius + center.position;
			transform.position = Vector3.MoveTowards (transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
			move++;
		}if (move == 10) {
			SoundManager.PlaySound ("redMove");
		}
		if (move == 100) {
			click.count ();
			click.probes--;
			Destroy (transform.gameObject);
		}
	}
}
