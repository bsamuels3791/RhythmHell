using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameManager : MonoBehaviour {

	public Text pizzaDisplay;
	public Text perfectDisplay;
	public Text okayDisplay;
	public Text scoreDisplay;

	// Use this for initialization
	void Start () {
		// Grabbing the data
		int pizzas = GlobalRhythmControl.finishedPizza;
		int finalScore = GlobalRhythmControl.score;
		int perfects = GlobalRhythmControl.perfectCount;
		int okays = GlobalRhythmControl.okayCount;

		// Changing the texts
		pizzaDisplay.text += pizzas;
		perfectDisplay.text += perfects;
		okayDisplay.text += okays;
		scoreDisplay.text += finalScore;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
