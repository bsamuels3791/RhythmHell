using UnityEngine;
using System.Collections;

public enum TicketType{
	CHEESE,
	SAUSAGE,
	VEGGIE
}

public class Ticket : MonoBehaviour {
	public string type;
	private TicketType ticketObj;

	// Use this for initialization
	void Start () {
		switch (type) {
			case "Cheese":
				ticketObj = TicketType.CHEESE;
				break;
			case "Sausage":
			ticketObj = TicketType.SAUSAGE;
				break;
			case "Veggie":
			ticketObj = TicketType.VEGGIE;
				break;
		}
	
	}
	
	public TicketType GetTicketType(){ return ticketObj; }
}
