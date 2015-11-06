using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeatMachine : MonoBehaviour
{
	public const float ERROR_ALLOWANCE = 0.0075f;

    public float bpm = 120;
    // this.timeSigBeat is only the "numerator" in the time signature
    // We'll assume the "denominator" is 4
    public int timeSigBeat = 4;
    public int offsetBeats = 0;
    public float globalOffset = 0;
    
    private AudioSource source;

    // Calculates the current position of the song by finding the difference between
    // the current time and the time that this BeatMachine was created
    public int GetAudioPosition()
    {
        return (int)(source.time * 1000);
    }
	public int GetMeasure(float offset = 0)
    {
        return Mathf.FloorToInt(((GetAudioPosition() + offset) / GetMillisecondsPerBeat() + offsetBeats) / timeSigBeat);
    }
	public float GetBeatPosition(float offset = 0)
    {
        return ((GetAudioPosition() + offset + ERROR_ALLOWANCE) / GetMillisecondsPerBeat() + (timeSigBeat + offsetBeats)) % timeSigBeat;
    }
	public int GetTimeSigBeat()
    {
        return timeSigBeat;
    }
	public float GetMillisecondsPerBeat()
    {
        return 60000 / bpm;
    }
	public float GetAbsoluteBeatPosition()
    {
        return GetMeasure() * timeSigBeat + GetBeatPosition() + offsetBeats;
    }

	void Awake()
    {
        source = GetComponent<AudioSource>();
        Reset(bpm, timeSigBeat, offsetBeats);
	}

	/**
	 * Constructor
	 */
    void Start()
    {
        source.Play();
    }
	
    /**
     * Resets the Beat Machine
     */
	public void Reset(float bpm, int timeSigBeat, int offsetBeats = 0)
	{
		this.bpm = bpm;
		this.timeSigBeat = timeSigBeat;
		this.offsetBeats = offsetBeats;
        source.Stop();
	}
		
	/**
	 * Gets the position in milliseconds based on the song info given
	 */
	public static float InMilliseconds(float bpm, int timeSigBeat, int measure, float beat, int offsetBeat = 0)
	{
		float millisecondsPerBeat = 60000 / bpm;
		return (offsetBeat + measure * timeSigBeat + beat) * millisecondsPerBeat;
	}
	
	public static float InMillisecondsAbsolute(float bpm, int timeSigBeat, float beat)
	{
		float millisecondsPerBeat = 60000 / bpm;
		return beat * millisecondsPerBeat;
	}
		
	/**
	 * Gets the beat position of the song based on the position offset
	 */
	public static float InBeats(float bpm, int timeSigBeat, float position)
	{
		float millisecondsPerBeat = 60000 / bpm;
		float beat = position / millisecondsPerBeat;
		beat %= bpm;
			
		return beat;
	}

}
