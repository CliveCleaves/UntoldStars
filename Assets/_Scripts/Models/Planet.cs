using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Orbital {

	public Planet() {
		
	}
	
	public void Generate(int maxMoons) {
		OrbitalDistance = (ulong) Random.Range (50, 800) * 1000000 * 1000;
		TimeToOrbit = this.OrbitTimeForDistance(OrbitalDistance); // TODO Fix with real physics!
		GraphicID = Random.Range(1, 14);

		int m = Random.Range (0, maxMoons + 1);
		for (int i = 0; i < m; i++) {
			Orbital moon = new Orbital();
			this.AddChild (moon);
			moon.OrbitalDistance = (ulong) Random.Range(2, 5) * 10000000000; // TODO Fix makes no sense
			moon.TimeToOrbit = moon.OrbitTimeForDistance(moon.OrbitalDistance); // TODO Fix with real physics.
			moon.GraphicID = 15;
		}
	}
}
