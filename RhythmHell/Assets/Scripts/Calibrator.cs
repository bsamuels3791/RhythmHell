using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Calibrator : RhythmObject
{
    private const int MAX_SAMPLES = 8;
    // How many samples to take before we hide the visuals from the user, making them rely on sound
    private const int HIDE_BUTTONS_AT = 2;

    private RhythmAnalyzer analyzer;
    private bool calibrating;
    private bool showThrowing;

    private GameObject hideButtonSprite;
    private Text noticeText;

    /* --Red button was originally around x=4.2, green around x=5.1, no peeking image at x=0-- */
    public Sprite idleA, idleB, throwing;
    private int previousBeat;
    private GameObject chefSprite;

    // Use this for initialization
    void Start()
    {
        analyzer = new RhythmAnalyzer();
        calibrating = true;

        hideButtonSprite = GameObject.Find("HideButtons");
        noticeText = GameObject.Find("Notice").GetComponent<Text>();

        chefSprite = GameObject.Find("Chef");
        // Start the previous beat 1 before the starting beat of the beat machine
        // so that the Rhythm Object will immediately update because it thinks the
        // beat machine is changing from the previous beat to the current beat
        previousBeat = (int)beatMachine.GetBeatPosition() - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (calibrating)
        {
            List<float> samples = analyzer.GetSamples();

            // Still collecting calibration samples
            if (samples.Count < MAX_SAMPLES)
            {
                // Check if we need to hide the sampling visuals
                if (samples.Count == HIDE_BUTTONS_AT)
                {
                    hideButtonSprite.GetComponent<SpriteRenderer>().enabled = true;
                }
                // Check for Spacebar press
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    float sample = beatMachine.GetBeatPosition();
                    analyzer.AddSample(sample);

                    // Show thowing sprite when player hits space
                    showThrowing = true;
                }

               /* GameObject.Find("Notice").GetComponent<Text>().text =
                    "Samples collected:\n" +
                    samples.Count + " / " + MAX_SAMPLES;*/
                noticeText.text =
                    "Samples collected:\n" +
                    samples.Count + " / " + MAX_SAMPLES;
            }

            // Finished collecting samples, stop the metronome music and prepare to move to the next scene
            else
            {
                float offset = analyzer.GetAverageOffset();

                /*GameObject.Find("Notice").GetComponent<Text>().text =
                    "Global Offset:\n" + offset;*/
                noticeText.text =
                    "Global Offset: \n" + offset;

                calibrating = false;
                beatMachine.Stop();

                GlobalRhythmControl.globalOffset = offset * 1000;
            }

            // Check if OnBeat should be called
            int currentBeat = (int)beatMachine.GetBeatPosition();

            if (previousBeat != currentBeat)
            {
                OnBeat(beatMachine.GetMeasure(), currentBeat);
                previousBeat = currentBeat;
            }
        }
        else
        {
            /*GameObject.Find("Notice").GetComponent<Text>().text =
                "Press Space to move to the game!\n\n Or, press 'R' to re-do the calibration";*/
            noticeText.text =
                "Press Space to move to the game!\n\n Or, press 'R' to re-do the calibration";

            // Check for Spacebar press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(2);
            }

            // Check for 'R' release
            if (Input.GetKeyUp(KeyCode.R))
            {
                Application.LoadLevel(1);
            }
        }
    }

    /**
     * Called when the beat is hit
     */
    void OnBeat(int measure, int beat)
    {
        if (showThrowing)
        {
            chefSprite.GetComponent<SpriteRenderer>().sprite = throwing;
            showThrowing = false;
        }
        else if (chefSprite.GetComponent<SpriteRenderer>().sprite == idleA)
        {
            chefSprite.GetComponent<SpriteRenderer>().sprite = idleB;
        }
        else
        {
            chefSprite.GetComponent<SpriteRenderer>().sprite = idleA;
        }
    }

}