using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameManager : MonoBehaviour {

	public Text pizzaDisplay;
	public Text perfectDisplay;
	public Text okayDisplay;
	public Text scoreDisplay;
	public Sprite pass, fail;
	public Image banner;
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

		if(pizzas >= 17){
			banner.sprite = pass;
		}else{
			banner.sprite = fail;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
