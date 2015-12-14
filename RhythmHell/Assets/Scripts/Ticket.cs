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
	public Ticket otherTicket;

	private TicketType ticketObj;
	private int CompletedTickets;

	// Use this for initialization
	void Start () {
		setType(type);
	}

	public void changeType(string newType = null, int random = 10){
		if(otherTicket){
			ticketObj = otherTicket.GetTicketType();
			setType(ticketObj);
			otherTicket.changeType(newType,random);
		}else{
			if(newType != null){
				// Changing type
				setType(newType);
	        }
	        else if (random != 10)
	        {
				switch(random){
				case 0:
					setType("Cheese");
					break;
				case 1:
					setType("Sausage");
					break;
				case 2:
					setType("Veggie");
					break;
				}
			}else{
				Debug.Log("no data passed into changeType");
			}
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

	void setType(TicketType newType){
		switch (newType) {
		case TicketType.CHEESE:
			gameObject.GetComponent<SpriteRenderer> ().sprite = cheeseTicket;
			break;
		case TicketType.SAUSAGE:
			gameObject.GetComponent<SpriteRenderer> ().sprite = sausageTicket;
			break;
		case TicketType.VEGGIE:
			gameObject.GetComponent<SpriteRenderer> ().sprite = veggieTicket;
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
