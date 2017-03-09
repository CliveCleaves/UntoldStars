using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform Player;
	float speed = 10f;
	Vector3 Target;

	// Update is called once per frame
	void Update () {
		if (Player) {

			Target = Player.position;
			Target.z = -10;

			float step = speed * Time.smoothDeltaTime;

			//transform.position = Vector3.Lerp (transform.position, Target, step);
			transform.position = Target;
		}
	}
}
