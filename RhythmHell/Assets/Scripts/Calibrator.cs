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

    private GameObject hideButtonSprite;
    private Text noticeText;

    // Use this for initialization
    void Start()
    {
        analyzer = new RhythmAnalyzer();
        calibrating = true;

        hideButtonSprite = GameObject.Find("HideButtons");
        noticeText = GameObject.Find("Notice").GetComponent<Text>();
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
}
