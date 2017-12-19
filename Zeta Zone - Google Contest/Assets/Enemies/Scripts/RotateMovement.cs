using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMovement : MonoBehaviour {

	//Geral
	GameObject target;
	float maxDistance = 30;
	float forwardSpeed = -2f;
	public int movementType;

	//Rotate
	float rotateSpeed = 1;
	//Octagon Movement 8 Enemies
	float octagonPoint;
	Vector2[] octagonWaypoint;
	float octagonSpeed = 2;
	int octagonTargetNumber;
	//Hexagon Movement 6 Enemies
	float hexagonPoint;
	Vector2[] hexagonWaypoint;
	float hexagonSpeed = 2;
	int hexagonTargetNumber;
	//Lozangle Movement 4 Enemies
	float lozanglePoint;
	Vector2[] lozangleWaypoint;
	float lozangleSpeed = 2;
	int lozangleTargetNumber;
	//Triangle Movement 3 Enemies
	float trianglePoint;
	Vector2[] triangleWaypoint;
	float triangleSpeed = 2;
	int triangleTargetNumber;
	//Square Movement 4 Enemies
	float squarePoint;
	Vector2[] squareWaypoint;
	float squareSpeed = 2;
	int squareTargetNumber;
	//Circular Movement 3 Enemies
	float circleSpeed = 2;
	float circleSize;
	float circleGrowSpeed = 0;
	float xPos;
	float yPos;
	float zPos;

	void Start () 
	{
		//Geral
		target = GameObject.Find ("Main Camera");
		movementType = GameObject.Find("EnemyController").GetComponent<Spawner>().movementType;
		//Octagon Movement
		octagonWaypoint = new Vector2 [8];
		octagonPoint = Random.Range (4, maxDistance/2);
		octagonWaypoint[0] = new Vector2 (0, -octagonPoint*2);
		octagonWaypoint[1] = new Vector2 (-octagonPoint, -octagonPoint);
		octagonWaypoint[2] = new Vector2 (-octagonPoint*2, 0);
		octagonWaypoint[3] = new Vector2 (-octagonPoint, octagonPoint);
		octagonWaypoint[4] = new Vector2 (0, octagonPoint*2);
		octagonWaypoint[5] = new Vector2 (octagonPoint, octagonPoint);
		octagonWaypoint[6] = new Vector2 (octagonPoint*2, 0);
		octagonWaypoint[7] = new Vector2 (octagonPoint, -octagonPoint);
		//Hexagon Movement
		hexagonWaypoint = new Vector2 [6];
		hexagonPoint = Random.Range (4, maxDistance/2);
		hexagonWaypoint[0] = new Vector2 (0, -hexagonPoint);
		hexagonWaypoint[1] = new Vector2 (-hexagonPoint, -hexagonPoint);
		hexagonWaypoint[2] = new Vector2 (-hexagonPoint, hexagonPoint);
		hexagonWaypoint[3] = new Vector2 (0, hexagonPoint);
		hexagonWaypoint[4] = new Vector2 (hexagonPoint, hexagonPoint);
		hexagonWaypoint[5] = new Vector2 (hexagonPoint, -hexagonPoint);
		//Lozangle Movement
		lozangleWaypoint = new Vector2 [4];
		lozanglePoint = Random.Range (3, maxDistance/2);
		lozangleWaypoint[0] = new Vector2 (0, -lozanglePoint);
		lozangleWaypoint[1] = new Vector2 (-lozanglePoint, 0);
		lozangleWaypoint[2] = new Vector2 (0, lozanglePoint);
		lozangleWaypoint[3] = new Vector2 (lozanglePoint, 0);
		//Triangle Movement
		triangleWaypoint = new Vector2 [3];
		trianglePoint = Random.Range (3, maxDistance/2);
		triangleWaypoint[0] = new Vector2 (-trianglePoint, -trianglePoint);
		triangleWaypoint[1] = new Vector2 (0, trianglePoint*2);
		triangleWaypoint[2] = new Vector2 (trianglePoint, -trianglePoint);
		//Square Movement
		squareWaypoint = new Vector2 [4];
		squarePoint = Random.Range (3, maxDistance/2);
		squareWaypoint[0] = new Vector2 (-squarePoint, -squarePoint);
		squareWaypoint[1] = new Vector2 (-squarePoint, squarePoint);
		squareWaypoint[2] = new Vector2 (squarePoint, squarePoint);
		squareWaypoint[3] = new Vector2 (squarePoint, -squarePoint);
		//Circular Movement
		circleSize = Random.Range (3, maxDistance/2);
	}
	
	void Update () 
	{
		Rotate ();
		switch (movementType)
		{
			case 1:
				OctagonMovement ();
				break;
			case 2:
				HexagonMovement ();
				break;
			case 3:
				LozangleMovement ();
				break;
			case 4:
				TriangleMovement ();
				break;
			case 5:
				SquareMovement ();
				break;
			case 6:
				CircularMovement ();
				break;
		}
	}

	public void SetMovementType (int type)
	{
		movementType = type;
	}
	public void Rotate ()
	{
		foreach (Transform child in transform)
		{
			child.Rotate (rotateSpeed, 0, 0);
		}
	}

	public void OctagonMovement () //8 Enemies
	{
		foreach (Transform child in transform)
		{
			Vector2 pos = child.position;
			int targetPosition = octagonTargetNumber + child.GetSiblingIndex();
			if (targetPosition >= octagonWaypoint.Length)
			{
				targetPosition -= transform.childCount;
			}

			if (Vector3.Distance (target.transform.position, child.position) > maxDistance*2)
			{
				zPos = child.position.z + forwardSpeed * Time.deltaTime;
				child.position = Vector2.MoveTowards (pos, octagonWaypoint[targetPosition], octagonSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, zPos);

				if ((Vector2) child.position == octagonWaypoint[targetPosition]) {
					octagonTargetNumber = (octagonTargetNumber + 1) % octagonWaypoint.Length;
				}
			} 
			else
			{
				child.position = Vector2.MoveTowards (pos, octagonWaypoint[targetPosition], octagonSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, target.transform.position.z + maxDistance);

				if ((Vector2) child.position == octagonWaypoint[targetPosition]) {
					octagonTargetNumber = (octagonTargetNumber + 1) % octagonWaypoint.Length;
				}
			}
		}
	}

	public void HexagonMovement () //6 Enemies
	{
		foreach (Transform child in transform)
		{
			Vector2 pos = child.position;
			int targetPosition = hexagonTargetNumber + child.GetSiblingIndex();
			if (targetPosition >= hexagonWaypoint.Length)
			{
				targetPosition -= transform.childCount;
			}

			if (Vector3.Distance (target.transform.position, child.position) > maxDistance*2)
			{
				zPos = child.position.z + forwardSpeed * Time.deltaTime;
				child.position = Vector2.MoveTowards (pos, hexagonWaypoint[targetPosition], hexagonSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, zPos);

				if ((Vector2) child.position == hexagonWaypoint[targetPosition]) {
					hexagonTargetNumber = (hexagonTargetNumber + 1) % hexagonWaypoint.Length;
				}
			} 
			else
			{
				child.position = Vector2.MoveTowards (pos, hexagonWaypoint[targetPosition], hexagonSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, target.transform.position.z + maxDistance);

				if ((Vector2) child.position == hexagonWaypoint[targetPosition]) {
					hexagonTargetNumber = (hexagonTargetNumber + 1) % hexagonWaypoint.Length;
				}
			}
		}
	}

	public void LozangleMovement () //4 Enemies
	{
		foreach (Transform child in transform)
		{
			Vector2 pos = child.position;
			int targetPosition = lozangleTargetNumber + child.GetSiblingIndex();
			if (targetPosition >= lozangleWaypoint.Length)
			{
				targetPosition -= transform.childCount;
			}

			if (Vector3.Distance (target.transform.position, child.position) > maxDistance*2)
			{
				zPos = child.position.z + forwardSpeed * Time.deltaTime;
				child.position = Vector2.MoveTowards (pos, lozangleWaypoint[targetPosition], lozangleSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, zPos);

				if ((Vector2) child.position == lozangleWaypoint[targetPosition]) {
					lozangleTargetNumber = (lozangleTargetNumber + 1) % lozangleWaypoint.Length;
				}
			} 
			else
			{
				child.position = Vector2.MoveTowards (pos, lozangleWaypoint[targetPosition], lozangleSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, target.transform.position.z + maxDistance);

				if ((Vector2) child.position == lozangleWaypoint[targetPosition]) {
					lozangleTargetNumber = (lozangleTargetNumber + 1) % lozangleWaypoint.Length;
				}
			}
		}
	}

	public void TriangleMovement () //3 Enemies
	{
		foreach (Transform child in transform)
		{
			Vector2 pos = child.position;
			int targetPosition = triangleTargetNumber + child.GetSiblingIndex();
			if (targetPosition >= triangleWaypoint.Length)
			{
				targetPosition -= transform.childCount;
			}

			if (Vector3.Distance (target.transform.position, child.position) > maxDistance*2)
			{
				zPos = child.position.z + forwardSpeed * Time.deltaTime;
				child.position = Vector2.MoveTowards (pos, triangleWaypoint[targetPosition], triangleSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, zPos);

				if ((Vector2) child.position == triangleWaypoint[targetPosition]) {
					triangleTargetNumber = (triangleTargetNumber + 1) % triangleWaypoint.Length;
				}
			} 
			else
			{
				child.position = Vector2.MoveTowards (pos, triangleWaypoint[targetPosition], triangleSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, target.transform.position.z + maxDistance);

				if ((Vector2) child.position == triangleWaypoint[targetPosition]) {
					triangleTargetNumber = (triangleTargetNumber + 1) % triangleWaypoint.Length;
				}
			}
		}
	}

	public void SquareMovement () //4 Enemies
	{
		foreach (Transform child in transform)
		{
			Vector2 pos = child.position;
			int targetPosition = squareTargetNumber + child.GetSiblingIndex();
			if (targetPosition >= squareWaypoint.Length)
			{
				targetPosition -= transform.childCount;
			}

			if (Vector3.Distance (target.transform.position, child.position) > maxDistance*2)
			{
				zPos = child.position.z + forwardSpeed * Time.deltaTime;
				child.position = Vector2.MoveTowards (pos, squareWaypoint[targetPosition], squareSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, zPos);

				if ((Vector2) child.position == squareWaypoint[targetPosition]) {
					squareTargetNumber = (squareTargetNumber + 1) % squareWaypoint.Length;
				}
			} 
			else
			{
				child.position = Vector2.MoveTowards (pos, squareWaypoint[targetPosition], squareSpeed * Time.deltaTime);

				child.position = new Vector3 (child.position.x, child.position.y, target.transform.position.z + maxDistance);

				if ((Vector2) child.position == squareWaypoint[targetPosition]) {
					squareTargetNumber = (squareTargetNumber + 1) % squareWaypoint.Length;
				}
			}
		}
	}

	public void CircularMovement () //3 Enemies
	{

		foreach (Transform child in transform)
		{
			xPos = Mathf.Sin((Time.time+(child.GetSiblingIndex()*2)) * circleSpeed) * circleSize;
			yPos = Mathf.Cos((Time.time+(child.GetSiblingIndex()*2)) * circleSpeed) * circleSize;
			zPos = child.position.z + forwardSpeed * Time.deltaTime;
			circleSize += circleGrowSpeed;
			if (Vector3.Distance (target.transform.position, child.position) > maxDistance)
			{
				child.position = new Vector3 (xPos, yPos, zPos);
			} 
			else
			{
				child.position = new Vector3 (xPos, yPos, target.transform.position.z + maxDistance-2);
			}
			
		}
		
	}
}
