using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour {

	Color color;
	float rColorValue;
	float gColorValue;
	float bColorValue;

	void Start () {
		ChangeColor ();
	}

	public void ChangeColor ()
	{
		rColorValue = Random.value;
		gColorValue = Random.value;
		bColorValue = Random.value;
		color = new Color (rColorValue, gColorValue, bColorValue, 1);

		SetLightColor ();
		SetObjectColor ();
		SetTrailColor ();
		SetShootColor ();
	}

	void SetShootColor ()
	{
		foreach (Transform child in transform)
		{
			child.GetComponent<EnemyShoot>().SetColor (color);
		}
	}

	void SetTrailColor ()
	{
		foreach (Transform child in transform)
		{
			child.GetComponent<TrailRenderer>().startColor = new Color (rColorValue, gColorValue, bColorValue, 0.5f);
			child.GetComponent<TrailRenderer>().endColor = new Color (rColorValue, gColorValue, bColorValue, 0.5f);
		}
	}

	void SetObjectColor ()
	{
		foreach (Transform child in transform)
		{
			child.GetComponent<Renderer>().material.color = color;
		}
	}

	void SetLightColor ()
	{
		foreach (Transform child in transform)
		{
			child.GetComponent<Light>().color = color;
		}
	}
}
