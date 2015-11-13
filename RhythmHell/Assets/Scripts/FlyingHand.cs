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

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update () {

		if(gameObject.transform.position.y > 3.3){
			gameObject.transform.position = new Vector3(-8,-4.3f,0);
		}
		gameObject.transform.Translate(0,speed*Time.deltaTime,0,Space.World);

		//Checks the input
		if (Input.GetKeyDown(KeyCode.Space))
		{
			// The beat when the key was hit
			float keyHitBeat = beatMachine.GetBeatPosition(beatMachine.globalOffset) % 1;
			
			if (keyHitBeat < PERFECT_OFFSET || keyHitBeat > 1 - PERFECT_OFFSET)
			{
				perfectCount = perfectCount + 1;
			//	GameObject.Find("Rating").GetComponent<Text>().text = "PERFECT!";
			//	GameObject.Find("PerfectCount").GetComponent<Text>().text = "Perfects: " + perfectCount.ToString();
			}
			else if (keyHitBeat < OK_OFFSET || keyHitBeat > 1 - OK_OFFSET)
			{
				okCount = okCount + 1;
			//	GameObject.Find("Rating").GetComponent<Text>().text = "OK";
			//	GameObject.Find("OkCount").GetComponent<Text>().text = "Ok's: " + okCount.ToString();
			}
			else
			{
				booCount = booCount + 1;
			//	GameObject.Find("Rating").GetComponent<Text>().text = "Boo!";
			}
			
			
			
			Debug.Log(keyHitBeat);
		}
	}
}
