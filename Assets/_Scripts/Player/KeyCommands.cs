using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class KeyCommands : MonoBehaviour {
	float rotSpeed = 180.0F;
	float moveSpeed = 25.0F;

	Rigidbody2D rig;

	// Items for projectile.
	public GameObject projectile;
	float fireDelta = 0.2F;
	public Transform leftGunTip;
	public Transform rightGunTip;

	private float nextFire = 0.2F;
	private GameObject newProjectile;
	private GameObject newProjectile2;
	private float myTime = 0.0F;

	// Use this for initialization
	void Start () {
		rig = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		myTime = myTime + Time.deltaTime;
		// float v = Input.GetAxis ("Vertical");
		// float h = Input.GetAxis ("Horizontal");
		float v = CrossPlatformInputManager.GetAxis ("Vertical");
		float h = CrossPlatformInputManager.GetAxis ("Horizontal");

		if (v != 0 || h != 0) {
			float myAngle = Mathf.Atan2 (-h, v) * Mathf.Rad2Deg;
			float angle = Mathf.MoveTowardsAngle (transform.eulerAngles.z, myAngle, rotSpeed * Time.deltaTime);
			// This is the turning
			transform.eulerAngles = new Vector3 (0, 0, angle);
			// This is the forward thrust
			rig.AddForce (transform.up * 2 * moveSpeed);
		} else {
			rig.velocity = Vector3.Lerp (rig.velocity, Vector3.zero, 0.2f);
		}
		// Firing commands.
		if (Input.GetButton("Fire1") && myTime > nextFire) {
			nextFire = myTime + fireDelta;
			Vector3 pos = transform.position;
			pos.z = 0;
			Camera.main.GetComponent<CameraShake>().startShake();
			newProjectile = Instantiate(projectile, leftGunTip.position, transform.rotation) as GameObject;
			newProjectile2 = Instantiate(projectile, rightGunTip.position, transform.rotation) as GameObject;

			Destroy(newProjectile, 4f);
			Destroy(newProjectile2, 4f);

			nextFire = nextFire - myTime;
			myTime = 0.0F;
		}
	}
}
