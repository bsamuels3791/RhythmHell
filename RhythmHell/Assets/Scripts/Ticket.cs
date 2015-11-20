using UnityEngine;
using System.Collections;

public enum TicketType{
	CHEESE,
	SAUSAGE,
	VEGGIE
}

public class Ticket : MonoBehaviour {
	//public string type = "Cheese";  // If no type is specified, default to cheese
	// Sprite for Cheese, Sausage, and Veggie tickets
	public Sprite cheeseTicket;
	public Sprite sausageTicket;
	public Sprite veggieTicket;

	public TicketType ticketObj;

	public TicketType GetTicketType(){ 
		switch (ticketObj) {
		// Default case will fall through to cheese
		default:
		case TicketType.CHEESE:
			ticketObj = TicketType.CHEESE;
			gameObject.GetComponent<SpriteRenderer> ().sprite = cheeseTicket;
			break;
		case TicketType.SAUSAGE:
			ticketObj = TicketType.SAUSAGE;
			gameObject.GetComponent<SpriteRenderer> ().sprite = sausageTicket;
			break;
		case TicketType.VEGGIE:
			ticketObj = TicketType.VEGGIE;
			gameObject.GetComponent<SpriteRenderer> ().sprite = veggieTicket;
			break;
		}

		return ticketObj; 
	}
}
