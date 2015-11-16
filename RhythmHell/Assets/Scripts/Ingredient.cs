using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour {
	public string type;
	private string layer;
	private GameObject appliedLayer;

	void Start(){
		switch(type) {
			case "Veggie":
				layer = "veggie_layer";
				break;
			case "Sausage":
				layer = "sausage_layer";
				break;
			case "Cheese":
				layer = "cheese_layer";
				break;
			case "Sauce":
				layer = "sauce_layer";
				break;
			default:
				layer = "none";
				break;
		}

		if (layer != "none") {
			appliedLayer = GameObject.Find("PizzaObject").transform.Find(layer).gameObject;
		}
	}

	public void AddThis(){
		appliedLayer.GetComponent<SpriteRenderer> ().enabled = true;
	}

}
