using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Calibrator : RhythmObject
{
    private const int MAX_SAMPLES = 8;

    private RhythmAnalyzer analyzer;
    private bool calibrating;

    // Use this for initialization
    void Start()
    {
        analyzer = new RhythmAnalyzer();
        calibrating = true;
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
                // Check for Spacebar press
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    float sample = beatMachine.GetBeatPosition();
                    analyzer.AddSample(sample);
                }

                GameObject.Find("Notice").GetComponent<Text>().text =
                    "Samples collected:\n" +
                    samples.Count + " / " + MAX_SAMPLES;
            }

            // Finished collecting samples, stop the metronome music and prepare to move to the next scene
            else
            {
                float offset = analyzer.GetAverageOffset();

                GameObject.Find("Notice").GetComponent<Text>().text =
                    "Global Offset:\n" + offset;

                calibrating = false;
                beatMachine.Stop();

                GlobalRhythmControl.globalOffset = offset * 1000;
            }
        }
        else
        {
            GameObject.Find("Notice").GetComponent<Text>().text =
                "Press Space to move to the game!";

            // Check for Spacebar press
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Application.LoadLevel(3);
            }
        }
    }
}
