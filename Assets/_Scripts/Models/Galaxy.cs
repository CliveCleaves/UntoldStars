using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Galaxy {

	public Galaxy() {
		// Don't do procedural gen in a constructor.
		SolarSystems = new List <SolarSystem>();
	}

	public List<SolarSystem> SolarSystems;

	public void Generate(int numStars) {
		// Optional seed
		//Random.InitState(######);
		for (int i = 0; i < numStars; i++) {
			SolarSystem ss = new SolarSystem ();
			ss.Generate ();

			SolarSystems.Add (ss);
		}
	}
	public void LoadFromFile(string fileName) {
		
	}
	public void Update(ulong timeSinceStart) {
		foreach (SolarSystem ss in SolarSystems) {
			ss.Update (timeSinceStart);
		}
	}
}
