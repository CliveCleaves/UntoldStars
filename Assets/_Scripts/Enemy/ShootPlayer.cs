using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour {
	bool left = true;
	public GameObject projectile;
	float fireDelta = 0.6F;

	private float nextFire = 0.6F;
	private GameObject newProjectile;
	private float myTime = 0.0F;
	
	// Update is called once per frame
	void Update () {
		myTime = myTime + Time.deltaTime;
	}
	void shoot() {
		// Cooldowns
		if (myTime > nextFire) {
			// TODO Figure out left cannon, right cannon switching.
			Vector3 launchpoint;
			if (left) {
				launchpoint = transform.FindChild ("LeftCannon").transform.position;
			} else {
				launchpoint = transform.FindChild ("RightCannon").transform.position;
			}
			left = !left;

			nextFire = myTime + fireDelta;

			newProjectile = Instantiate(projectile, launchpoint, transform.rotation) as GameObject;
			newProjectile.layer = 13;
			newProjectile.GetComponent<MoveUp> ().moveSpeed = 10f;
			Destroy(newProjectile, 5f);

			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
	}
}
