using UnityEngine;
using System.Collections;

public enum TicketType{
	CHEESE,
	SAUSAGE,
	VEGGIE
}

public class Ticket : MonoBehaviour {
	// Sprite for Cheese, Sausage, and Veggie tickets
	public Sprite cheeseTicket;
	public Sprite sausageTicket;
	public Sprite veggieTicket;
	public string type = "Cheese";  // If no type is specified, default to cheese

	private TicketType ticketObj;
	private int CompletedTickets;

	// Use this for initialization
	void Start () {
		setType(type);
	}

	public void changeType(string newType = default(string), int random = default(int)){
		if(newType != null){
			// Changing type
			setType(newType);
        }
        else if (random != 0)
        {
			switch(random){
			case 1:
				setType("Cheese");
				break;
			case 2:
				setType("Sausage");
				break;
			case 3:
				setType("Veggie");
				break;
			}
		}else{
			Debug.Log("no type passed into changeType");
		}
	}

	void setType(string newType){
		switch (newType) {
		case "Cheese":
			ticketObj = TicketType.CHEESE;
			gameObject.GetComponent<SpriteRenderer> ().sprite = cheeseTicket;
			//SetSprite("ticket_cheese");
			break;
		case "Sausage":
			ticketObj = TicketType.SAUSAGE;
			gameObject.GetComponent<SpriteRenderer> ().sprite = sausageTicket;
			//SetSprite("ticket_sausage");
			break;
		case "Veggie":
			ticketObj = TicketType.VEGGIE;
			gameObject.GetComponent<SpriteRenderer> ().sprite = veggieTicket;
			//SetSprite("ticket_veggie");
			break;
		}
		/*
		GlobalRhythmControl.finishedPizza ++;
		should move this if statement and maybe increment to the flying hand class... not sure
		if(GlobalRhythmControl.finishedPizza == 20){
			GlobalRhythmControl.score = 
			Application.loadLevel
		}
		*/
	}

	public TicketType GetTicketType(){ 
		switch (ticketObj) {
		// Default case will fall through to cheese
		default:
		case TicketType.CHEESE:
			ticketObj = TicketType.CHEESE;
			break;
		case TicketType.SAUSAGE:
			ticketObj = TicketType.SAUSAGE;
			break;
		case TicketType.VEGGIE:
			ticketObj = TicketType.VEGGIE;
			break;
		}

		return ticketObj; 
	}
}
