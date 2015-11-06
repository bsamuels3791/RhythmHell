using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BeatMachine
{
	public const float ERROR_ALLOWANCE = 0.0075f;

	private int measure;
	private float beat;
	private float bpm;
	private int offsetBeats;
	private int previousMeasure;
	private float previousBeat;
	private AudioSource song;

	// this.timeSigBeat is only the "numerator" in the time signature
	// We'll assume the "denominator" is 4
	private int timeSigBeat;

	private int initialTime;
		
	private bool metronome;

	// Keeps track of when the beatmachine goes off
	private List<Beat> beats;
		
	public int GetMeasure() { return measure; }
	public float GetBeatPosition() { return beat; }
	public float GetBpm() { return bpm; }
	public int GetTimeSigBeat(){ return timeSigBeat; }
	public float GetMillisecondsPerBeat() { return 60000 / bpm; }
		
	public bool GetMetronome() { return metronome; }
	public void SetMetronome(bool x) { metronome = x; }
		
	public bool GetFinished() { return this.beats.length == 0; }
		
	public float GetAbsoluteBeatPosition() { return measure * timeSigBeat + beat + offsetBeats; }
		
	/**
	 * Sets a SoundObject for the BeatMachine to follow
	public void Follow(SoundObject song)
	{
		this.song = song;
	}
	 */

	/**
	 * Constructor
	 */
	public BeatMachine(float bpm, int timeSigBeat, int offsetBeats = 0)
	{
		Reset(bpm, timeSigBeat, offsetBeats);
	}
		
	public void Reset(float bpm, int timeSigBeat, int offsetBeats = 0)
	{
		this.bpm = bpm;
		this.timeSigBeat = timeSigBeat;
		this.offsetBeats = offsetBeats;

		// Our BeatMachine is starting at the beginning of the song
		measure = Mathf.Floor(this.offsetBeats / this.timeSigBeat);
		beat = (this.timeSigBeat + this.offsetBeats) % this.timeSigBeat;
		previousMeasure = -Int32.MaxValue;
		previousBeat = -Int32.MaxValue;
			
		initialTime = 0;

		// Prepares the beats to be populated
		beats = new List<Beat>();
	}

	/**
	 * Our very useful tick() function will be called every time the timer goes off
	 */
	public void Update()
	{
		// Gets the time in milliseconds that this BeatMachine was started
		if (initialTime == 0)
			initialTime = DateTime.Now;
			
		// Calculates the current position of the song by finding the difference between
		// the current time and the time that this BeatMachine was created
		int position;
		
	
		if (!song)
			position = DateTime.Now - initialTime;
		else
			position = (int)(song.time * 1000);


		measure = Mathf.Floor((position / GetMillisecondsPerBeat() + offsetBeats) / timeSigBeat);
		beat = (position / GetMillisecondsPerBeat() + (timeSigBeat + offsetBeats)) % timeSigBeat;
			
		// Checks if there are any beats in the _beats
		/*if (beats.length > 0)
		{
			// Checks if the time is right for the BeatMachine to go off
			if (measure == beats[0].measure && beat + ERROR_ALLOWANCE >= beats[0].position)
			{
				// The BeatMachine goes off and the beat is removed from the _beats
				Beat();
				beats.RemoveAt(0);
			}
		}*/
	}

	/**
	 * Fills the _beats with information for when the BeatMachine should go off
	 */
	public void PopulateBeats(List<Beat> beatData)
	{
		for (int i = 0; i < beatData.Count; i++){
			beats.Add(beatData[i]);
       }
	}

	/**
	 * Called when the BeatMachine is told to go off
		 
	private void Beat()
	{
		ticking = true;
	}*/
		
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
