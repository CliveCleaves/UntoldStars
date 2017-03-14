using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {
	// This should probably be renamed as its using physics instead of transform.
	public float moveSpeed = 20f;
	AudioSource shootSound;
	Rigidbody2D rig;
	// Use this for initialization
	void Start () {
		shootSound = this.GetComponent<AudioSource> ();
		Vector3 pos = transform.position;
		pos.z = -5;
		AudioSource.PlayClipAtPoint(shootSound.clip, pos);

		rig = this.GetComponent<Rigidbody2D> ();
		rig.AddForce(transform.up * moveSpeed, ForceMode2D.Impulse);
	}

	// Update is called once per frame
	void FixedUpdate () {
		
		//transform.position += transform.up * moveSpeed * Time.smoothDeltaTime;
	}
}
