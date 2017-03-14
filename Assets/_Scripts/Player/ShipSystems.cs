using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSystems : MonoBehaviour {
	GameObject newGO;
	Text myText;
	float cockpitSystem; // Weapon Damage Modifier?
	int cockpitLevel;

	float fuselageSystem; // Engine Efficiency?
	int fuselageLevel;

	float leftwingSystem; // Turning?
	int leftwingLevel;

	float rightwingSystem; // No clue yet
	int rightwingLevel;

	// Use this for initialization
	void Start () {
		newGO = new GameObject("myTextGO");
		cockpitSystem = 100.0f;
		fuselageSystem = 100.0f;
		leftwingSystem = 100.0f;
		rightwingSystem = 100.0f;
		myText = newGO.AddComponent<Text>();
		Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
		myText.font = ArialFont;
		myText.material = ArialFont.material;

	}
	
	// Update is called once per frame
	void Update () {
		// Essentially drain each system slowly.
		InvokeRepeating("drainSystems", 0, 5f);

	}
	void drainSystems() {
		this.cockpitSystem -= 0.5f;
		this.fuselageSystem -= 0.5f;
		this.leftwingSystem -= 0.5f;
		this.rightwingSystem -= 0.5f;
		drawText ();
	}
	void drawText() {
		// TODO Figure out where things are.


		newGO.transform.SetParent(this.transform);


		myText.text = "Ta-dah!";
	}
}
