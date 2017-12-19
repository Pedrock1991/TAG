using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
	public int damage;
	public float knockbackDuration = 0.02f;
	[Range (10,50)]
	public float knockbackPower;
	private Player player;
	private bool hit = true;
	private float nextHit;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
	}

	void Update () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
		if (nextHit > 0) {
			nextHit -= Time.deltaTime;
		} else {
			hit = true;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		Debug.Log("Hit");
		if(col.CompareTag("Player")) {
			if (hit) {
				GameManager.instance.SetCurrentHealth (damage);
				StartCoroutine(player.Knockback(knockbackDuration, knockbackPower));
				hit = false;
				nextHit = 3.0f;
			}
		}
	}
}
