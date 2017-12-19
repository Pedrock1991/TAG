using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {
	public int moveSpeed;
	public float maxMoveDistance;
	public Transform player;

	Vector3 origin;

	[Header("Movement Direction")]
	public bool vertical;
	public bool horizontal;
	public bool diagonalUpRight;
	public bool diagonalDownRight;
	public bool diagonalUpLeft;
	public bool diagonalDownLeft;
	

	void Start () {
		origin = transform.position;
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		transform.LookAt (player);

		transform.Rotate (new Vector3 (0,+90,0), Space.Self);//correcting the original rotation

		if (horizontal) {
				transform.position = new Vector3 (origin.x + Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance), 
				origin.y, 
				origin.z);
		}

		if (vertical) {
			transform.position = new Vector3 (origin.x, 
			origin.y + Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance), 
			origin.z);
		}


		if (diagonalUpRight) {
			transform.position = new Vector3 (origin.x + Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance),
		 		origin.y + Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance), 
		 		origin.z);
		}

		if (diagonalDownRight) {
			transform.position = new Vector3 (origin.x + Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance),
		 		origin.y - Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance), 
		 		origin.z);
		}

		if (diagonalUpLeft) {
			transform.position = new Vector3 (origin.x - Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance),
		 		origin.y + Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance), 
		 		origin.z);
		}

		if (diagonalDownLeft) {
			transform.position = new Vector3 (origin.x - Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance),
		 		origin.y - Mathf.PingPong (Time.time * moveSpeed, maxMoveDistance), 
		 		origin.z);
		}
		
	}
}
