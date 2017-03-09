using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		Galaxy = new Galaxy ();
		Galaxy.Generate (1);
	}

	public Galaxy Galaxy;

	// Update is called once per frame
	void Update () {
		ChangeTime (1000);
	}
	ulong galacticTime = 0;

	public void ChangeTime(int numSeconds) {
		galacticTime = galacticTime + (uint) numSeconds;

		Galaxy.Update (galacticTime);
	}
}
