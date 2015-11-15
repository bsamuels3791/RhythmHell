using UnityEngine;
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

	// Use this for initialization
	void Start () {
		// Start the previous beat 1 before the starting beat of the beat machine
		// so that the Rhythm Object will immediately update because it thinks the
		// beat machine is changing from the previous beat to the current beat
		previousBeat = (int)beatMachine.GetBeatPosition() - 1;
	}
	
	// Update is called once per frame
	void Update () {

		/*
		if(gameObject.transform.position.y > 3.0f){
			gameObject.transform.position = new Vector3(-8,-4.0f,0);
		}
		gameObject.transform.Translate(0,speed*Time.deltaTime,0,Space.World);
		 */

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

		int currentBeat = (int)beatMachine.GetBeatPosition();
		
		if (previousBeat != currentBeat)
		{
			OnBeat(beatMachine.GetMeasure(), currentBeat);
			previousBeat = currentBeat;
		}
	}

	/**
     * Called when the beat is hit
     */
	void OnBeat(int measure, int beat)
	{
		// Check if a new beat has started
		if ((int)beat != previousBeat)
		{
			// Hand will reset to SAUCE position every 4 beats
			gameObject.transform.position = new Vector3(-8.0f, -4.0f + (float)(2*beat), 0.0f);
		}
	}
}
