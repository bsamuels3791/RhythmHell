﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RhythmTracker : RhythmObject
{
    public const float PERFECT_OFFSET = 0.125f;
    public const float OK_OFFSET = 0.25f;

    public float globalOffset = 0;
	public float perfectCount = 0;
	public float okCount = 0;

	// Update is called once per frame
	void Update ()
    {
        // Check for Spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // The beat when the key was hit
            float keyHitBeat = beatMachine.GetBeatPosition(-beatMachine.globalOffset) % 1;

            if (keyHitBeat < PERFECT_OFFSET || keyHitBeat > 1 - PERFECT_OFFSET)
            {
				perfectCount = perfectCount + 1;
                GameObject.Find("Rating").GetComponent<Text>().text = "PERFECT!";
				GameObject.Find("PerfectCount").GetComponent<Text>().text = "Perfects: " + perfectCount.ToString();
            }
            else if (keyHitBeat < OK_OFFSET || keyHitBeat > 1 - OK_OFFSET)
            {
				okCount = okCount + 1;
				GameObject.Find("Rating").GetComponent<Text>().text = "OK";
				GameObject.Find("OkCount").GetComponent<Text>().text = "Ok's: " + okCount.ToString();
			}
            else
            {
                GameObject.Find("Rating").GetComponent<Text>().text = "Boo!";
            }



            Debug.Log(keyHitBeat);
        }

		// Check for pause/unpause
		/*if (Input.GetKeyUp (KeyCode.P)) {
			// toggle the game to pause
		}
		 */
    }
}
