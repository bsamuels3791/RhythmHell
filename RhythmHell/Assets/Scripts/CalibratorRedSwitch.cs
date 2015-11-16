using UnityEngine;
using System.Collections;

public class CalibratorRedSwitch : RhythmObject
{
    private const int BEEP_DURATION = 10;

    private int previousBeat;
    private int beepTimer;

    // Use this for initialization
    void Start()
    {
        // Start the previous beat 1 before the starting beat of the beat machine
        // so that the Rhythm Object will immediately update because it thinks the
        // beat machine is changing from the previous beat to the current beat
        previousBeat = (int)beatMachine.GetBeatPosition() - 1;

        beepTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (beepTimer == 0)
        {
            gameObject.transform.FindChild("OnBeat").gameObject.SetActive(false);
        }
        else
        {
            beepTimer++;

            if (beepTimer >= BEEP_DURATION)
            {
                beepTimer = 0;
            }
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
        if (beat < 3)
        {
            gameObject.transform.FindChild("OnBeat").gameObject.SetActive(true);
            beepTimer++;
        }
    }
}
