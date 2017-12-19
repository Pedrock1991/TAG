using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] enemyForms;

	float distance = 100;
	int form;
	public int movementType; //6 Types -- 1-Octagon|2-Hexagon|3-Lozangle|4-Triangle|5-Square|6-Circular
						        //Enemies      8	|     6   |     4    |    3     |    4   |     3
	int previousMovement;

	bool test;
	void Start () {
		SpawnEnemies ();
	}
	
	void Update () {
		if(!test)
		{
			SpawnEnemies ();
			test = true;
		}
	}

	public void SpawnEnemies ()
	{
		movementType = Random.Range(1,7); //Number Beetween 1 and 6
		while (movementType == previousMovement)
		{
			movementType = Random.Range(1,7);
		}

		switch (movementType)
		{
			case 1:
				MakeEnemies (8);
				break;
			case 2:
				MakeEnemies (6);
				break;
			case 3:
				MakeEnemies (4);
				break;
			case 4:
				MakeEnemies (3);
				break;
			case 5:
				MakeEnemies (4);
				break;
			case 6:
				MakeEnemies (3);
				break;
		}

		previousMovement = movementType;
	}

	void MakeEnemies (int quantity)
	{
		Vector3 pos = new Vector3 (0, 0, distance);
		form =   Random.Range(0,4); //Number Beetween 0 and 3
		GameObject go = new GameObject();
		string ScriptName;
		System.Type MyScriptType;
		go.name = "Enemies";

		for (int i = 0; i < quantity; i++) 
		{
			GameObject clone = Instantiate(enemyForms[form]);
			clone.transform.SetParent(go.transform);
			clone.transform.position = pos;
		}

		//We have a string holding a script name
       	ScriptName = "RotateMovement";
        //We need to fetch the Type
        MyScriptType = System.Type.GetType (ScriptName + ",Assembly-CSharp");
        //Now that we have the Type we can use it to Add Component
        go.AddComponent (MyScriptType);

		//We have a string holding a script name
       	ScriptName = "ColorController";
        //We need to fetch the Type
        MyScriptType = System.Type.GetType (ScriptName + ",Assembly-CSharp");
        //Now that we have the Type we can use it to Add Component
        go.AddComponent (MyScriptType);
	}
}
