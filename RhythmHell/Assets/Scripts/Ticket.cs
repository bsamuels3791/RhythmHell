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

	// Use this for initialization
	void Start () {
		setType(type);
	}

	void changeType(string newType = default(string)){
		if(newType != null){
			// Changing type
			setType(newType);
		} else{
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
