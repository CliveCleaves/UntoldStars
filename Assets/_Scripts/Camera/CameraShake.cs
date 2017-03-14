using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
	Vector3 originalCameraPosition;

	float shakeAmt = 0;

	Camera mainCamera;
	void Start() {
		mainCamera = Camera.main;	
	}

	public void startShake() {
		//originalCameraPosition = mainCamera.transform.position;
		shakeAmt = 0.05f;
		InvokeRepeating("Shake", 0, .01f);
		Invoke("StopShaking", 0.3f);

	}

	void Shake() {
		if(shakeAmt>0) {
			float quakeAmt = Random.value*shakeAmt*2 - shakeAmt;
			Vector3 pp = mainCamera.transform.position;
			pp.y+= quakeAmt; // can also add to x and/or z
			mainCamera.transform.position = pp;
		}
	}

	void StopShaking() {
		CancelInvoke("Shake");
		//mainCamera.transform.position = originalCameraPosition;
	}
}
