using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
	public GameObject explosion;
	int damage;
	// Use this for initialization
	void Start () {
		// TODO get this from the gameobject.
		damage = 34;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D coll) {
		Camera.main.GetComponent<CameraShake>().startShake();
		GameObject go = Instantiate (explosion, coll.gameObject.transform.position , Quaternion.identity);
		if (coll.gameObject.GetComponent<EnemyHealth>()) {
			coll.gameObject.GetComponent<EnemyHealth> ().Hit (damage);
		}
		if (coll.gameObject.GetComponent<PlayerHealth>()) {
			coll.gameObject.GetComponent<PlayerHealth> ().Hit (damage);
		}
		Destroy (go, 3f);
		Destroy (this.gameObject);

	}
}
