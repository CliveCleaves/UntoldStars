using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	int startingHealth = 100;
	private int enemyHealth;
	public GameObject destroyedLeft;
	public GameObject destroyedRight;

	// Use this for initialization
	void Start () {
		enemyHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void Hit(int damage) {
		enemyHealth -= damage;
		if (enemyHealth <= 0) {

			// Current force
			Vector2 vel = this.gameObject.GetComponent<Rigidbody2D>().velocity;
			GameObject gol = Instantiate (destroyedLeft, transform.position, transform.rotation);
			gol.GetComponent<Rigidbody2D>().velocity = vel;

			// GameObject gor = Instantiate (destroyedRight, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}

}
