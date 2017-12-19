using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour {
    public Player player;

    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent <Player> ();
    }

    void Update () {
        if (!player.isActiveAndEnabled) {
            player = GameObject.FindGameObjectWithTag ("Player").GetComponent <Player> ();
        }
    }

    public void ButtonPressedDown (BaseEventData e) {
		player.OnJumpInputDown ();
	}

	public void ButtonPressedUp (BaseEventData e) {
		player.OnJumpInputUp ();
	}
}