using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbital {

	public Orbital() {
		TimeToOrbit = 1;
		Children = new List<Orbital>();
		InitAngle = UnityEngine.Random.Range (0, Mathf.PI * 2);
	}

	public Orbital Parent;
	public List<Orbital> Children;

	public float InitAngle;
	public float OffsetAngle; // Angle around the parent, in Radians.
	public ulong OrbitalDistance; // in meters
	public ulong TimeToOrbit;

	public int GraphicID;



	// We need to be able to get an X, Y, coordinate for our location
	// for the purpose of rendering the Orbital on the screen.
	public Vector3 Position {
		get {
			// TODO Convert our orbit info into a vector that we can use
			// to render something as a Unity GameObject

			// Consider whether we should be saving this in a private
			// variable whenever we update angle.

			Vector3 myOffset = new Vector3(
				Mathf.Sin(InitAngle + OffsetAngle) * OrbitalDistance,
				-Mathf.Cos(InitAngle + OffsetAngle) * OrbitalDistance,
				0	// Z is locked to zero - 2D
			);
			if (Parent != null) {
				myOffset += Parent.Position;
			}
			return myOffset;
		}
	}
	public Quaternion Rotation {
		get {
			// Hacky? An inefficient way to have planets pointing at sun...
			// TODO make planets rotate and have the light from sun be static.
			Vector3 dir = this.Position - Vector3.zero;
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

			return Quaternion.Euler(0, 0, angle+90);
		}
	}

	public void Update(ulong timeSinceStart) {
		// Advance our angle by the correct amount of time.
		OffsetAngle =  (2f * Mathf.PI *  (float)timeSinceStart) / TimeToOrbit;

		// Update all of our children.
		for (int i = 0; i < Children.Count; i++) {
			Children [i].Update (timeSinceStart);
		}
	}

	public ulong OrbitTimeForDistance (ulong OrbitalDistance) {
		// Kepler's 3rd law is P^2 = a^3
		// Where P is orbital period in years
		// a is avg distance from sun in AU
		double AU = getAUfromMeter(OrbitalDistance);

		// We have years, as p = (root)a^3
		double years = Mathf.Sqrt(Mathf.Pow ((float)AU, 3));

		// Now we need seconds. 1 year = 3.1536e+7
		double seconds = years * (3.1536 * Mathf.Pow(10,7));

		return (ulong)seconds;
	}

	public double getAUfromMeter(ulong OrbitalDistance) {
		// m -> AU 6.684587123 × 10^-12
		double convert = (6.684587123 * Mathf.Pow(10, -12));
		return (double)OrbitalDistance * (6.684587123 * Mathf.Pow(10, -12));
	}
		
	public void AddChild(Orbital c) {
		c.Parent = this;
		Children.Add (c);
	}

	public void RemoveChild(Orbital c) {
		c.Parent = null;
		Children.Remove (c);
	}
}
