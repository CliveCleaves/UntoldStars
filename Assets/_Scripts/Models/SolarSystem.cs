using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : Orbital {
	public void Generate() {
		// 	Single start single planet
		Orbital myStar = new Orbital();
		myStar.GraphicID = 0;
		this.AddChild (myStar);

		for (int i = 0; i < 8; i++) {

			Planet planet = new Planet ();
			planet.Generate (3);
			myStar.AddChild (planet);
		}
	}
}
