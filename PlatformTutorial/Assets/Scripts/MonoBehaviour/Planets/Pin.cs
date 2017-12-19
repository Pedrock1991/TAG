using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Direction {
	Up,
	Down,
	Left,
	Right
}

public class Pin : MonoBehaviour {

	[Header("Options")] //
	public bool IsAutomatic;
	public bool HideIcon;
	public string SceneToLoad;
	public int stageType;

	[Header("Pins")] //
	public Pin UpPin;
	public Pin DownPin;
	public Pin LeftPin;
	public Pin RightPin;

	private Dictionary<Direction, Pin> _pinDirections;

	void Start () {
		_pinDirections = new Dictionary <Direction,Pin> {
			{ Direction.Up, UpPin },
			{ Direction.Down, DownPin },
			{ Direction.Left, LeftPin },
			{ Direction.Right, RightPin }
		};

		if (HideIcon) {
			GetComponent<SpriteRenderer> ().enabled = false;
		}

	}

	public Pin GetPinInDirection (Direction direction) {
		switch (direction) {
		case Direction.Up:
			return UpPin;
		case Direction.Down:
			return DownPin;
		case Direction.Left:
			return LeftPin;
		case Direction.Right:
			return RightPin;
		default:
			return null;
		}
	}

	public Pin GetNextPin (Pin pin) {
		return _pinDirections.FirstOrDefault (x => x.Value != null && x.Value != pin).Value;
	}

	private void OnDrawGizmos () {
		if (UpPin != null)
			DrawLine (UpPin);
		if (DownPin != null)
			DrawLine (DownPin);
		if (LeftPin != null)
			DrawLine (LeftPin);
		if (RightPin != null)
			DrawLine (RightPin);
	}

	protected void DrawLine (Pin pin) {
		Gizmos.color = Color.blue;
		Gizmos.DrawLine (transform.position, pin.transform.position);
	}
}
