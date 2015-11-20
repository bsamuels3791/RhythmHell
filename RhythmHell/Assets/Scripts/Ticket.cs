using UnityEngine;
using System.Collections;

public enum TicketType{
	CHEESE,
	SAUSAGE,
	VEGGIE
}

public class Ticket : MonoBehaviour {
	public string type = "Cheese";  // If no type is specified, default to cheese
	private TicketType ticketObj;

	// Use this for initialization
	void Start () {
		/*switch (type) {
			case "Cheese":
				ticketObj = TicketType.CHEESE;
				//SetSprite("ticket_cheese");
				break;
			case "Sausage":
				ticketObj = TicketType.SAUSAGE;
				//SetSprite("ticket_sausage");
				break;
			case "Veggie":
				ticketObj = TicketType.VEGGIE;
				//SetSprite("ticket_veggie");
				break;
		}*/
	
	}

	/*void SetSprite(string spriteName){
		Sprite changeTemp = GameObject.Find (spriteName).GetComponent<SpriteRenderer> ().sprite;

		gameObject.GetComponent<SpriteRenderer> ().sprite = changeTemp;
	}*/
	
	public TicketType GetTicketType(){ 
		switch (type) {
		// Default case will fall through to cheese
		default:
		case "Cheese":
			ticketObj = TicketType.CHEESE;
			//SetSprite("ticket_cheese");
			break;
		case "Sausage":
			ticketObj = TicketType.SAUSAGE;
			//SetSprite("ticket_sausage");
			break;
		case "Veggie":
			ticketObj = TicketType.VEGGIE;
			//SetSprite("ticket_veggie");
			break;
		}

		return ticketObj; 
	}
}
