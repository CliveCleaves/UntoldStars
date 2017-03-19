using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	public GameObject destroyedViper;
	Image Healthbar;
	float health = 300;
	Camera mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		Healthbar = mainCamera.transform.FindChild ("HealthCanvas").FindChild ("Healthbar").GetComponent<Image>();
	}

	void updateHealth() {
		Healthbar.fillAmount = (health / 300);
	}

	public void Hit(int damage) {
		health -= damage;
		updateHealth ();

		// Death
		if (health <= 0) {
			
			Vector2 vel = this.gameObject.GetComponent<Rigidbody2D>().velocity;
			Time.timeScale = 0.2f;
			mainCamera.GetComponent<CameraFollow> ().deathCam = true;
			GameObject gol = Instantiate (destroyedViper, transform.position, transform.rotation);
			gol.GetComponent<Rigidbody2D>().velocity = vel;

			// GameObject gor = Instantiate (destroyedRight, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
