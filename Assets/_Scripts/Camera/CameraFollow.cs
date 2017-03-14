using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public Transform Player;
	float speed = 1.75f;
	Vector3 Target;

	float duration = 5.0f;
	float elapsed = 0.0f;
	public bool deathCam = false;

	// Update is called once per frame
	void FixedUpdate () {
		if (Player) {

			Target = Player.position + Player.transform.up*3f;
			Target.z = -10;

			float step = speed * Time.smoothDeltaTime;

			transform.position = Vector3.Lerp (transform.position, Target, step);
			//transform.position = Target;
		}
		if (deathCam == true) {
			elapsed += Time.deltaTime / duration;
			Camera.main.orthographicSize = Mathf.SmoothStep (5f, 3f, 5f * elapsed);
		}
	}
}
