using UnityEngine;
using System.Collections;

public class RhythmMoveInGrid : RhythmObject
{
    private int previousBeat;

    // Use this for initialization
    void Start()
    {
        // Start the previous beat 1 before the starting beat of the beat machine
        // so that the Rhythm Object will immediately update because it thinks the
        // beat machine is changing from the previous beat to the current beat
        previousBeat = (int)beatMachine.GetBeatPosition() - 1;
    }

    // Update is called once per frame
    void Update()
    {
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
           gameObject.transform.position = new Vector3(
                -4 + ((int)beat),
                4 - measure % 8
            );
        }
    }
}
