using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager5 : MonoBehaviour {
	//Simon Variables
	public SpriteRenderer[] colours;
	private AudioSource coloursSounds;
	public AudioClip[] sounds;
	private int colourSelect;

	public float stayLit;
	private float stayLitCounter;

	public float waitBetweenLight;
	private float waitBetweenLightCounter;

	private bool shouldBeLit;
	private bool shouldBeDark;

	public List <int> activeSequence;
	private int positionInSequence;

	private bool gameActive;
	public int inputInSequence;

	private LevelManager LM;
	private Player player;
	
	public AudioSource correct;

	//Game Variables
	public int numberOfSequences;
	
	void Start () {
		LM = FindObjectOfType <LevelManager> ();
		player = FindObjectOfType <Player> ();
		coloursSounds = GetComponent <AudioSource> ();
	}

	void Update () {
		if (LM.startBonus){
			LM.gameStarted = true;
			LM.startBonus = false;
		}

		if (numberOfSequences <= 0) {
			LM.Win ();
		}
			
		if (shouldBeLit) {
			stayLitCounter -= Time.deltaTime;
			colours [activeSequence[positionInSequence]].color = new Color (colours [activeSequence[positionInSequence]].color.r,
																			colours [activeSequence[positionInSequence]].color.g,
																			colours [activeSequence[positionInSequence]].color.b, 1f);
			if (stayLitCounter < 0) {
				colours [activeSequence[positionInSequence]].color = new Color (colours [activeSequence[positionInSequence]].color.r,
																				colours [activeSequence[positionInSequence]].color.g,
																				colours [activeSequence[positionInSequence]].color.b, 0.5f);
				coloursSounds.Stop ();
				shouldBeLit = false;
				shouldBeDark = true;
				waitBetweenLightCounter = waitBetweenLight;

				positionInSequence++;
			}
		}

		if (shouldBeDark) {
			waitBetweenLightCounter -= Time.deltaTime;

			if (positionInSequence >= activeSequence.Count) {
				shouldBeDark = false;
				LM.gameStarted = true;
				gameActive = true;
			} else {
				if (waitBetweenLightCounter < 0) {

					colours [activeSequence[positionInSequence]].color = new Color (colours [activeSequence[positionInSequence]].color.r,
																					colours [activeSequence[positionInSequence]].color.g,
																					colours [activeSequence[positionInSequence]].color.b, 1f);
					coloursSounds.PlayOneShot(sounds[activeSequence[positionInSequence]]);

					stayLitCounter = stayLit;
					shouldBeLit = true;
					shouldBeDark = false;
				}
			}
		}
		
	}

	public void StartGame () {
		activeSequence.Clear ();

		positionInSequence = 0;
		inputInSequence = 0;

		colourSelect = Random.Range (0, colours.Length);

		activeSequence.Add (colourSelect);

		colours [activeSequence[positionInSequence]].color = new Color (colours [activeSequence[positionInSequence]].color.r,
																		colours [activeSequence[positionInSequence]].color.g,
																		colours [activeSequence[positionInSequence]].color.b, 1f);
		coloursSounds.PlayOneShot(sounds[activeSequence[positionInSequence]]);

		stayLitCounter = stayLit;
		shouldBeLit = true;
	}

	public void ColourPressed (int whichLight) {
		if (gameActive) {
			if (activeSequence [inputInSequence] == whichLight) {
				Debug.Log ("Correct");
				inputInSequence++;
				if (inputInSequence >= activeSequence.Count) {
					positionInSequence = 0;
					inputInSequence = 0;

					colourSelect = Random.Range (0, colours.Length);

					activeSequence.Add (colourSelect);

					colours [activeSequence[positionInSequence]].color = new Color (colours [activeSequence[positionInSequence]].color.r,
																					colours [activeSequence[positionInSequence]].color.g,
																					colours [activeSequence[positionInSequence]].color.b, 1f);
					coloursSounds.PlayOneShot(sounds[activeSequence[positionInSequence]]);

					stayLitCounter = stayLit;
					shouldBeLit = true;

					LM.gameStarted = false;
					gameActive = false;
					correct.Play ();
					numberOfSequences--;
				}
			} else {
				Debug.Log ("Incorrect");

				GameManager.instance.SetCurrentHealth (1);
				StartCoroutine(player.Knockback(0.25f, 10));

				positionInSequence = 0;
				inputInSequence = 0;
				stayLitCounter = stayLit;
				shouldBeLit = true;

				LM.gameStarted = false;
				gameActive = false;
			}
		}


	}
}
