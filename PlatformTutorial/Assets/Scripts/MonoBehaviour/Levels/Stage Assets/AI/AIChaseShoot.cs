using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChaseShoot : MonoBehaviour {
	[Header("Chase")]
	public Transform player;
	public int moveSpeed;
	public float minDistance;
	[Header("Shoot")]
	public Transform projectile;
	public float maxShootDistance;
	public int projectileSpeed;
	public float shotInterval;
	public float shotTime = 0;

	[Header("Keys")]
	public bool chase;
	public bool shoot;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	void Update () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;

		transform.LookAt (player);
		transform.Rotate (new Vector3 (0,+90,0), Space.Self);//correcting the original rotation

		if (chase) {
			if (Vector2.Distance (transform.position, player.position) >= minDistance) {
				transform.position = Vector2.MoveTowards (transform.position, player.position, moveSpeed * Time.deltaTime);
			}
		}
		if (shoot) {
			if (Vector2.Distance (transform.position, player.position) <= maxShootDistance && (Time.time - shotTime) > shotInterval) {
				Shooting ();
			}
		}
	}
	void Shooting () {
		shotTime = Time.time;
		Vector2 direction = (player.position - transform.position).normalized;
		Transform bullet;
		
		Debug.Log ("SHOOT");

		bullet = Instantiate (projectile, 
			transform.position, 
			transform.rotation);

		bullet.rotation = new Quaternion (transform.rotation.x, transform.rotation.y, transform.rotation.z * -1.0f, transform.rotation.w);
		bullet.GetComponent <Rigidbody2D> ().velocity = direction * projectileSpeed;

		Destroy(bullet.gameObject, 10);
	}
}
