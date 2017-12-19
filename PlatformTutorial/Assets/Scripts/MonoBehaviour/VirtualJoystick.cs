using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image joystickBase;
	private Image joystickControl;
	private Vector3 inputVector;

	private void Start () {
		joystickBase = GetComponent<Image> ();
		joystickControl = transform.GetChild (0).GetComponent<Image> ();
	}

	public virtual void OnDrag (PointerEventData ped) {
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (joystickBase.rectTransform,
			   ped.position,
			   ped.pressEventCamera,
			   out pos)) 
		{
			pos.x = (pos.x / joystickBase.rectTransform.sizeDelta.x);
			pos.y = (pos.y / joystickBase.rectTransform.sizeDelta.y);

			inputVector = new Vector3 (pos.x * 2, pos.y * 2, 0);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

			//Move Joystick Control
			joystickControl.rectTransform.anchoredPosition = 
				new Vector3 (inputVector.x * (joystickBase.rectTransform.sizeDelta.x / 3),
							inputVector.y * (joystickBase.rectTransform.sizeDelta.y / 3));
		}
	}

	public virtual void OnPointerDown (PointerEventData ped) {
		OnDrag (ped);
	}

	public virtual void OnPointerUp (PointerEventData ped) {
		inputVector = Vector3.zero;
		joystickControl.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float Horizontal () {
		if (inputVector.x != 0) {
			return inputVector.x;
		} else {
			return Input.GetAxis ("Horizontal");
		}
	}

	public float Vertical () {
		if (inputVector.y != 0) {
			return inputVector.y;
		} else {
			return Input.GetAxis ("Vertical");
		}
	}
}
