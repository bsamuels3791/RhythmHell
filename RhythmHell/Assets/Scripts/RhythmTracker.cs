using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RhythmTracker : RhythmObject
{
    public const float PERFECT_OFFSET = 0.125f;
    public const float OK_OFFSET = 0.25f;

    public float globalOffset = 0;
	
	// Update is called once per frame
	void Update ()
    {
        // Check for pause/ unpause
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // The beat when the key was hit
            float keyHitBeat = beatMachine.GetBeatPosition(beatMachine.globalOffset) % 1;

            if (keyHitBeat < PERFECT_OFFSET || keyHitBeat > 1 - PERFECT_OFFSET)
            {
                GameObject.Find("Rating").GetComponent<Text>().text = "PERFECT!";
            }
            else if (keyHitBeat < OK_OFFSET || keyHitBeat > 1 - OK_OFFSET)
            {
                GameObject.Find("Rating").GetComponent<Text>().text = "OK";
            }
            else
            {
                GameObject.Find("Rating").GetComponent<Text>().text = "Boo!";
            }

            Debug.Log(keyHitBeat);
        }
    }
}
