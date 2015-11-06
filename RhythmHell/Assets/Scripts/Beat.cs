// A virtual representation of a musical beat that contains information
// about when a note is played
public class Beat
{
	private int measure;
	private float position;
		
	public int GetMeasure() { return measure; }
	public float GetPosition() { return position; }

	// Accepts parameters for which measure the beat is in and where in
	// the measure (position) the beat is played
	public Beat(int measure, float  position)
	{
		this.measure = measure;
		this.position = position;
	}
		
	public override string ToString()
	{
		return "{" + measure + ", " + position + "}";
	}
}

