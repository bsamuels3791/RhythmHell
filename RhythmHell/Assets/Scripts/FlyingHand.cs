﻿using UnityEngine;
using System.Collections;

public class FlyingHand : RhythmObject {

	public const float PERFECT_OFFSET = 0.125f;
	public const float OK_OFFSET = 0.25f;

	public float globalOffset = 0;
	public float perfectCount = 0;
	public float okCount = 0;
	public float booCount = 0;
	public float speed = 0;

	private int previousBeat;
	private float previousHalfBeat;

	// Use this for initialization
	void Start () {
		// Start the previous beat 1 before the starting beat of the beat machine
		// so that the Rhythm Object will immediately update because it thinks the
		// beat machine is changing from the previous beat to the current beat
		previousBeat = (int)beatMachine.GetBeatPosition() - 1;
		previousHalfBeat = (int)beatMachine.GetBeatPosition() - 1;
		speed = beatMachine.bpm / 60.0f; // speed = beats per second

		/*
		globalOffset = GameObject.Find("//Something//").GetComponent<Script>().offset;
		*/
	 }

	// Update is called once per frame
	void Update () {

		// This code seems to get the hand sliding at the proper pace
		/*
		if(gameObject.transform.position.y > 3.0f){
			gameObject.transform.position = new Vector3(-8,-4.0f,0);
		}
		gameObject.transform.Translate(0,2*speed*Time.deltaTime,0,Space.World);
		*/

		int currentBeat = (int)beatMachine.GetBeatPosition();

		//Checks the input
		if (Input.GetKeyDown(KeyCode.Space))
		{

			// The beat when the key was hit
			float keyHitBeat = beatMachine.GetBeatPosition(beatMachine.globalOffset) % 1;

			if (keyHitBeat < PERFECT_OFFSET || keyHitBeat > 1 - PERFECT_OFFSET)
			{
				perfectCount = perfectCount + 1;
				Debug.Log("Perfect");

			//	GameObject.Find("Rating").GetComponent<Text>().text = "PERFECT!";
			//	GameObject.Find("PerfectCount").GetComponent<Text>().text = "Perfects: " + perfectCount.ToString();
			}
			else if (keyHitBeat < OK_OFFSET || keyHitBeat > 1 - OK_OFFSET)
			{
				okCount = okCount + 1;
				Debug.Log("OK");
			//	GameObject.Find("Rating").GetComponent<Text>().text = "OK";
			//	GameObject.Find("OkCount").GetComponent<Text>().text = "Ok's: " + okCount.ToString();
			}
			else
			{
				booCount = booCount + 1;
				Debug.Log ("Boo");
			//	GameObject.Find("Rating").GetComponent<Text>().text = "Boo!";
			}			
			//Debug.Log(keyHitBeat);
		}

		//float floatBeat = beatMachine.GetBeatPosition();
		float halfBeat = Mathf.Floor (beatMachine.GetBeatPosition() * 2) * 0.5f;
		
		if (previousBeat != currentBeat) {
			OnBeat (beatMachine.GetMeasure (), currentBeat);
			previousBeat = currentBeat;
		} 
		if (previousHalfBeat != halfBeat) {
			OnHalfBeat(beatMachine.GetMeasure(), halfBeat, currentBeat);
			previousHalfBeat = halfBeat;
		}
	}

	/*
    * Called when the beat is hit
    */
	void OnBeat(int measure, int beat)
	{
		// Check if a new beat has started
		if ((int)beat != previousBeat)
		{
			// Hand will reset to SAUCE position every 4 measures
			//gameObject.transform.position = new Vector3(-8.0f, -4.0f + (float)(2*measure % 8), 0.0f);
			// Reset every 4 beats
			gameObject.transform.position = new Vector3(-8.0f, -4.0f + (float)(2*beat), 0.0f);

			// Scale hand on each beat
			/*float scalePct = 175.0f - (25*(beat % 4));
			scalePct /= 100.0f;

			gameObject.transform.localScale = new Vector3 (scalePct, scalePct);*/

			/*if(beat == 0){
				gameObject.transform.localScale = new Vector3(1.75f, 1.75f);
			}
			else if(beat == 1){
				gameObject.transform.localScale = new Vector3(1.5f, 1.5f);
			}
			else if(beat == 2){
				gameObject.transform.localScale = new Vector3(1.25f, 1.25f);
			}
			else{
				gameObject.transform.localScale = new Vector3(1.0f, 1.0f);
			}*/
		}
	}

	void OnHalfBeat(int measure, float beatAbs, int beatInt){
		if (beatAbs - beatInt < 0.5f) {
			gameObject.transform.localScale = new Vector3(1.5f, 1.5f);
			//gameObject.transform.Translate(0.0f, -0.5f, 0.0f);
			gameObject.transform.position = new Vector3(-10.0f, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else {
			gameObject.transform.localScale = new Vector3(1.0f, 1.0f);
			//gameObject.transform.Translate(0.0f, 0.5f, 0.0f);
			gameObject.transform.position = new Vector3(-8.0f, gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}
}
