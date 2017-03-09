using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll) {
		GameObject go = Instantiate (explosion, coll.gameObject.transform.position , Quaternion.identity);
		if (coll.gameObject.GetComponent<EnemyHealth>()) {
			coll.gameObject.GetComponent<EnemyHealth> ().Hit (100);
		}
		Destroy (go, 3f);
		Destroy (this.gameObject);

	}
}
