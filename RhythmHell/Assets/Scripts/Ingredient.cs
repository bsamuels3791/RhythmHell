using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ingredient : MonoBehaviour {
	public string type;
	private string layer;
	private GameObject appliedLayer;
    private Vector3 startingPos;

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

            startingPos = new Vector3(
                GameObject.Find(layer).transform.position.x,
                GameObject.Find(layer).transform.position.y,
                GameObject.Find(layer).transform.position.z
            );
        }

    }

    public void AddThis( float offset ){
		appliedLayer.GetComponent<SpriteRenderer> ().enabled = true;

        GameObject.Find(layer).transform.position = new Vector3(
            startingPos.x + offset,
            startingPos.y,
            startingPos.z
        );
    }

}
