using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunGravity : MonoBehaviour {
	Rigidbody2D sunBody;
	// Use this for initialization
	void Start () {
		sunBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 125f);
		int i = 0;
		while (i < hitColliders.Length) {
			GameObject attractedTo;

			// Fighter
			if (hitColliders [i].transform.parent) {
				attractedTo = hitColliders [i].transform.parent.gameObject;
			} else {
				attractedTo = hitColliders [i].gameObject;
			}

			const float G = 0.0000000000667384f;



			Rigidbody2D targetRig = attractedTo.gameObject.GetComponent<Rigidbody2D> ();




			Vector3 heading = attractedTo.transform.position - transform.position;
			float distance = heading.magnitude;
			Vector3 direction = heading / distance; // This is now the normalized direction.

			if (distance > 2f) {
				Vector3 gravForce = ((-25f * direction) / distance) * 1.2f * targetRig.mass;
				hitColliders [i].attachedRigidbody.AddForce (gravForce);
			}
			i++;
		}
	}
}
