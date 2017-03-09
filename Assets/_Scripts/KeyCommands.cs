using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCommands : MonoBehaviour {
	float rotSpeed = 160.0F;
	float moveSpeed = 25.0F;
	Rigidbody2D rig;

	// Items for projectile.
	public GameObject projectile;
	float fireDelta = 0.3F;

	private float nextFire = 0.3F;
	private GameObject newProjectile;
	private float myTime = 0.0F;

	// Use this for initialization
	void Start () {
		rig = this.gameObject.GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
		myTime = myTime + Time.deltaTime;
		float v = Input.GetAxis ("Vertical");
		float h = Input.GetAxis ("Horizontal");

		if (v != 0 || h != 0) {
			float myAngle = Mathf.Atan2 (-Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")) * Mathf.Rad2Deg;
			float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, myAngle, rotSpeed * Time.deltaTime);
			// This is the turning
			transform.eulerAngles = new Vector3 (0, 0, angle);
			// This is the forward thrust
			rig.AddForce (transform.up * 2 * moveSpeed);
		} else {
			rig.velocity = Vector3.Lerp (rig.velocity, Vector3.zero, Time.deltaTime);
		}
		// Firing commands.
		if (Input.GetButton("Fire1") && myTime > nextFire) {
			nextFire = myTime + fireDelta;
			newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
			Destroy(newProjectile, 5f);

			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
	}
}
