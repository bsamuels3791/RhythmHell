using UnityEngine;
using System.Collections;

public class RhythmPulse : RhythmObject {

    private Vector3 startingScale;
    private int previousBeat;

    // Use this for initialization
    void Start () {
        startingScale = gameObject.transform.localScale;

        // Start the previous beat 1 before the starting beat of the beat machine
        // so that the Rhythm Object will immediately update because it thinks the
        // beat machine is changing from the previous beat to the current beat
        previousBeat = (int)beatMachine.GetBeatPosition() - 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = gameObject.transform.localScale;

        gameObject.transform.localScale = new Vector3
        (
            scale.x * 0.99f,
            scale.y * 0.99f,
            scale.z * 0.99f
        );

        gameObject.transform.FindChild("OnBeat").gameObject.SetActive(false);

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
        gameObject.transform.FindChild("OnBeat").gameObject.SetActive(true);
        gameObject.transform.localScale = new Vector3
        (
            startingScale.x,
            startingScale.y,
            startingScale.z
        );
    }
}
