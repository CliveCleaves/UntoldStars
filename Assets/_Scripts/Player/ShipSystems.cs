using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSystems : MonoBehaviour {
	public Text TextCockpit;
	public Text TextFuselage;
	public Text TextLeftWing;
	public Text TextRightWing;


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
		cockpitSystem = 100.0f;
		fuselageSystem = 100.0f;
		leftwingSystem = 100.0f;
		rightwingSystem = 100.0f;
		InvokeRepeating("drainSystems", 0, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		// Essentially drain each system slowly.
		TextCockpit.text = "Cockpit: " + cockpitSystem.ToString();
	}    
	void drainSystems() {
		
		this.cockpitSystem -= 0.5f;
		this.fuselageSystem -= 0.5f;
		this.leftwingSystem -= 0.5f;
		this.rightwingSystem -= 0.5f;

		// This actually works. What we could do, is show the text for a few seconds.
	}
	public void damageSystem(string Name, float Amt) {
		switch(Name){
		case "_Cockpit":
			this.cockpitSystem -= Amt;
			break;
		case "_Fuselage":
			this.fuselageSystem -= Amt;
			break;
		case "_LeftWing":
			this.leftwingSystem -= Amt;
			break;
		case "_RightWing":
			this.rightwingSystem -= Amt;
			break;
		}
	}
}
