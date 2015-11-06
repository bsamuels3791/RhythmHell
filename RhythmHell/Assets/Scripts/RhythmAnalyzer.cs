using System.Collections;
using System.Collections.Generic;

public class RhythmAnalyzer
{
	private float bpm;
	private List<float> samples;
		
	public List<float> GetSamples() { return samples; }

	public RhythmAnalyzer(float bpm)
	{
		this.bpm = bpm;
		this.samples = new List<float>();
	}
		
	/**
	 * Gets the average of the taps
	 */
	public float GetAverageOffset()
	{
		float offset = 0.0f;
			
		if (samples.length > 0)
		{
			for (int i= 0; i < samples.length; i++)
			{
				float tap = samples[i];
				tap %= 1;
				tap -= 0.5;
					
				offset += tap;
			}
				
			offset /= samples.length;
		}
			
		return offset;
	}
		
	/**
	 * Calculates the offset with the previously calculated offset
	 */
	public float CalculateOffsetWith(float currentOffset)
	{
		float offset = GetAverageOffset;
		offset += currentOffset;
		
		return offset;
	}
		
	/**
	 * Adds a beat position to be considered for analysis
	 */
	public void AddSample(float beatPosition)
	{
		samples.Add(beatPosition);
	}

}
