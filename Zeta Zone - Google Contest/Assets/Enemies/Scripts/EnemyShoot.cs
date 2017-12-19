using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public GameObject projectile;

	Color shootColor;
	GameObject target;
	float distance = 50;

	float fireRate = 2;
	float nextFire;
	float projectileSpeed = 50;

	void Start () {
		target = GameObject.Find ("Main Camera");
	}

	void Update () {
		transform.LookAt (target.transform);
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Shoot ();
		}
	}

	void Shoot ()
	{
		print (shootColor);
		if(Vector3.Distance (transform.position, target.transform.position) < distance)
		{
			Quaternion rotate = Quaternion.Euler (0, 90, 0);
			GameObject clone =  Instantiate(projectile, transform.position, rotate);
			clone.transform.GetComponent<Renderer> ().material.SetColor ("_TintColor", shootColor);
			clone.transform.localScale = new Vector3 (0.2f, 0.2f, 0.2f);
			/*
			if (clone.transform.position.x > 0)
			{
				if (clone.transform.position.y > 0)
				{
					clone.GetComponent<Rigidbody> ().AddForce (-projectileSpeed/5, -projectileSpeed/5, -projectileSpeed, ForceMode.Impulse);
				}
				else
				{
					clone.GetComponent<Rigidbody> ().AddForce (-projectileSpeed/5, projectileSpeed/5, -projectileSpeed, ForceMode.Impulse);
				}
			}
			else
			{
				if (clone.transform.position.y > 0)
				{
					clone.GetComponent<Rigidbody> ().AddForce (projectileSpeed/5, -projectileSpeed/5, -projectileSpeed, ForceMode.Impulse);
				}
				else
				{
					clone.GetComponent<Rigidbody> ().AddForce (projectileSpeed/5, projectileSpeed/5, -projectileSpeed, ForceMode.Impulse);
				}
			}
			*/
			clone.GetComponent<Rigidbody> ().AddForce (0, 0, -projectileSpeed, ForceMode.Impulse);

			Destroy (clone, 2);
		}
	}
	
	public void SetColor (Color color)
	{
		shootColor = color;
	}
}
