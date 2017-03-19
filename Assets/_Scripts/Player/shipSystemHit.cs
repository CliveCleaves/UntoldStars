using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipSystemHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log (this.name);
		Debug.Log ("hit");
		this.transform.parent.GetComponent<ShipSystems>().damageSystem (this.name, 10f);
	}
}
