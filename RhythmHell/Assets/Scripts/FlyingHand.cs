using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FlyingHand : RhythmObject {

	public const float PERFECT_OFFSET = 0.125f;
	public const float OK_OFFSET = 0.25f;

	public float globalOffset = 0;
	public float speed = 0;
	/*public int score = 0;
	public int perfectCount = 0;
	public int okCount = 0;
	public int booCount = 0;
	public int goodPizzas = 0;*/
	public Ingredient veggie;
	public Ingredient sausage;
	public Ingredient cheese;
	public Ingredient sauce;
	public Ticket ticket;
	public Text scoreText;
    public Text readyText;

	private int score = 0;
	private int perfectCountCurrent = 0;
	private int okCountCurrent = 0;
	private int booCountCurrent = 0;
	private int goodPizzas;

	private int previousBeat;
	private float previousHalfBeat;
	private TicketType ticketType;

    private bool enableInput;
	private bool[] ingredientsToAdd;
	private bool[] ingredientsAdded;

	// Use this for initialization
	void Start () {
		// Start the previous beat 1 before the starting beat of the beat machine
		// so that the Rhythm Object will immediately update because it thinks the
		// beat machine is changing from the previous beat to the current beat
		previousBeat = (int)beatMachine.GetBeatPosition() - 1;
		previousHalfBeat = (int)beatMachine.GetBeatPosition() - 1;
		speed = beatMachine.bpm / 60.0f; // speed = beats per second

        enableInput = false;
		ingredientsToAdd = new bool[3];
		ingredientsAdded = new bool[3];

		/*
		globalOffset = GameObject.Find("//Something//").GetComponent<Script>().offset;
		*/
	 }

	// Update is called once per frame
	void Update () {

		// This code seems to get the hand sliding at the proper pace
		/*
		if(gameObject.transform.position.y > 3.0f){
			gameObject.transform.position = new Vector3(-8,-4.0f,0);
		}
		gameObject.transform.Translate(0,2*speed*Time.deltaTime,0,Space.World);
		*/

		int currentBeat = (int)beatMachine.GetBeatPosition();

		// Only get the ticket on the first beat
		if (currentBeat == 0) {
			ticketType = ticket.GetTicketType();

			switch(ticketType){
				case TicketType.CHEESE:
					ingredientsToAdd[0] = true;
					ingredientsToAdd[1] = false;
					ingredientsToAdd[2] = false;
					break;
				case TicketType.SAUSAGE:
					ingredientsToAdd[0] = true;
					ingredientsToAdd[1] = true;
					ingredientsToAdd[2] = false;
					break;
				case TicketType.VEGGIE:
					ingredientsToAdd[0] = true;
					ingredientsToAdd[1] = false;
					ingredientsToAdd[2] = true;
					break;
			}
		}

		//Checks the input
		if (Input.GetKeyDown(KeyCode.Space) && enableInput)
		{
			// Add the ingredient
			switch(currentBeat){
			case 0:
				sauce.AddThis();
				break;
			case 1:
				cheese.AddThis();
				ingredientsAdded[0] = true;
				break;
			case 2:
				sausage.AddThis();
				ingredientsAdded[1] = true;
				break;
			case 3:
				veggie.AddThis();
				ingredientsAdded[2] = true;
				break;
			default:
				Time.timeScale = 0.0f;
				break;
			}


			// The beat when the key was hit
			float keyHitBeat = beatMachine.GetBeatPosition(beatMachine.globalOffset) % 1;

			if (keyHitBeat < PERFECT_OFFSET || keyHitBeat > 1 - PERFECT_OFFSET)
			{
				//perfectCount = perfectCount + 1;
				perfectCountCurrent++;
				Debug.Log("Perfect");

			//	GameObject.Find("Rating").GetComponent<Text>().text = "PERFECT!";
			//	GameObject.Find("PerfectCount").GetComponent<Text>().text = "Perfects: " + perfectCount.ToString();
			}
			else if (keyHitBeat < OK_OFFSET || keyHitBeat > 1 - OK_OFFSET)
			{
				//okCount = okCount + 1;
				okCountCurrent++;
				Debug.Log("OK");
			//	GameObject.Find("Rating").GetComponent<Text>().text = "OK";
			//	GameObject.Find("OkCount").GetComponent<Text>().text = "Ok's: " + okCount.ToString();
			}
			else
			{
				//booCount = booCount + 1;
				booCountCurrent++;
				Debug.Log ("Boo");
			//	GameObject.Find("Rating").GetComponent<Text>().text = "Boo!";
			}			
			//Debug.Log(keyHitBeat);
		}

		//float floatBeat = beatMachine.GetBeatPosition();
		float halfBeat = Mathf.Floor (beatMachine.GetBeatPosition() * 2) * 0.5f;
		
		if (previousBeat != currentBeat) {
			OnBeat (beatMachine.GetMeasure (), currentBeat);
			previousBeat = currentBeat;
		} 
		if (previousHalfBeat != halfBeat) {
			OnHalfBeat(beatMachine.GetMeasure(), halfBeat, currentBeat);
			previousHalfBeat = halfBeat;
		}
	}

	/*
    * Called when the beat is hit
    */
	void OnBeat(int measure, int beat)
	{
		// Check if a new beat has started
        if ((int)beat != previousBeat)
        {
            // Hand will reset to SAUCE position every 4 measures
            //gameObject.transform.position = new Vector3(-8.0f, -4.0f + (float)(2*measure % 8), 0.0f);
            // Reset every 4 beats
            gameObject.transform.position = new Vector3(-8.0f, -4.0f + (float)(2 * beat), 0.0f);

            // Update ready text for first and second measures
            if (measure == 0) { /*Don't need to actually update anything on first measure, just need to not go into else statement*/ }
            else if (measure == 1)
            {
                readyText.text = (4 - beat) + "!";
            }
            // On third measure and onward, have normal gameplay
            else
            {
                // If ready text is still active, de-activate it
                if (readyText.IsActive()) { 
                    readyText.gameObject.SetActive(false);
                    enableInput = true;
                }

                // Clear pizza on reset
                if (beat == 0)
                {
                    GameObject.Find("veggie_layer").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("sausage_layer").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("cheese_layer").GetComponent<SpriteRenderer>().enabled = false;
                    //GameObject.Find("sauce_layer").GetComponent<SpriteRenderer>().enabled = false;

                    // Set next pizza ticket

                    // First argument of changeType needs to be null to get ticket
                    // to change based on integer argument
                    ticket.changeType(null, (beatMachine.GetMeasure() % 3) + 1);

                    // Check if pizza was made correctly, then reset ingredient arrays
                    bool pizzaGood = true;
                    for (int i = 0; i < ingredientsToAdd.Length; i++)
                    {
                        if (ingredientsToAdd[i] != ingredientsAdded[i])
                        {
                            pizzaGood = false;
                            break;
                        }
                    }

                    if (pizzaGood)
                    {
                        goodPizzas++;
                        // Add to score based on how well the player did this pizza
                        score++; // +1 for getting pizza right
                        score += 2 * perfectCountCurrent; // +2 for each Perfect ingredient
                        score += okCountCurrent; // +1 for each OK ingredient
                        // +0 for each Boo ingredient
                        //Debug.Log (goodPizzas);
                    }

                    for (int i = 0; i < ingredientsToAdd.Length; i++)
                    {
                        ingredientsToAdd[i] = false;
                        ingredientsAdded[i] = false;
                    }

                    scoreText.text = "Score:  " + score.ToString();
                    perfectCountCurrent = 0;
                    okCountCurrent = 0;
                    booCountCurrent = 0;
                }

                /*// Scale hand on each beat
                float scalePct = 175.0f - (25*(beat % 4));
                scalePct /= 100.0f;

                gameObject.transform.localScale = new Vector3 (scalePct, scalePct);*/

                /*if(beat == 0){
                    gameObject.transform.localScale = new Vector3(1.75f, 1.75f);
                }
                else if(beat == 1){
                    gameObject.transform.localScale = new Vector3(1.5f, 1.5f);
                }
                else if(beat == 2){
                    gameObject.transform.localScale = new Vector3(1.25f, 1.25f);
                }
                else{
                    gameObject.transform.localScale = new Vector3(1.0f, 1.0f);
                }*/
            }
        }
	}

	void OnHalfBeat(int measure, float beatAbs, int beatInt){
		if (beatAbs - beatInt >= 0.5f) {
			gameObject.transform.localScale = new Vector3(1.5f, 1.5f);
			//gameObject.transform.Translate(0.0f, -0.5f, 0.0f);
			gameObject.transform.position = new Vector3(-10.0f, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		else {
			gameObject.transform.localScale = new Vector3(1.0f, 1.0f);
			//gameObject.transform.Translate(0.0f, 0.5f, 0.0f);
			gameObject.transform.position = new Vector3(-8.0f, gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}
}
