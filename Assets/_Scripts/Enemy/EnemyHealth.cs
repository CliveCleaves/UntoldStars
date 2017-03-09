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
			// TODO Maybe instantiate a dead ship on fire floating around?
			GameObject gol = Instantiate (destroyedLeft, transform.position, transform.rotation);
//			GameObject gor = Instantiate (destroyedRight, transform.position, transform.rotation);

			Destroy (gameObject);
		}
	}

}
