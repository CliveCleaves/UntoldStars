using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {
	float rotSpeed = 30f;
	float moveSpeed = 15f;
	Transform player;
	Rigidbody2D rig;
	public bool follow = false;

	void Start () {
		rig = this.GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (player == null) {
			// Find the players ship.
			GameObject go = GameObject.Find("PlayerObject");
			if (go != null) {
				player = go.transform;
			}
		}
		// At this point we've found player or no player exists.
		if (player == null)
			return;// Try again next frame.

		if (player != null) {
			Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
			Vector2 pos = new Vector2(transform.position.x, transform.position.y);
			// This is the distance from the player and the current ship/object.
			float distance = Vector2.Distance (target, pos);

			// This section handles rotation.
			Vector3 dir = player.position - transform.position;
			dir.Normalize ();
			float zAngle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg - 90;
			Quaternion desiredRot = Quaternion.Euler (0, 0, zAngle);

			// This section handles movement.
			if (distance > 4) {

				if (distance < 15 && follow) {
					rig.AddForce (transform.up * 2 * moveSpeed);
					
				}
			} else {
				this.gameObject.GetComponent<ShootPlayer>().SendMessage ("shoot");
				if (distance < 1.5f) {
					rig.AddForce (-transform.up * 2f * moveSpeed);
				}
				//rig.velocity = Vector2.Lerp(rig.velocity, Vector2.zero, Time.deltaTime);
				rig.AddForce (transform.right * 0.6f * moveSpeed);
			}
			transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}
	}
}
