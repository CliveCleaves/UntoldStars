using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemView : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gc = GameObject.FindObjectOfType<GameController> ();
		ShowSolarSystem (0);
	}

	GameController gc;
	SolarSystem solarSystem;

	public Sprite[] Sprites;
	uint zoomLevels = 3000000000; // *2 billion zoom

	Dictionary<Orbital, GameObject> orbitalGameObjectMap;

	public void ShowSolarSystem (int solarSystemID) {

		// First, clean up the solar system by deleting any old graphics.
		while (transform.childCount > 0) {
			Transform c = transform.GetChild (0);
			c.SetParent (null);
			Destroy (c.gameObject);
		}

		orbitalGameObjectMap = new Dictionary<Orbital, GameObject> ();

		solarSystem = gc.Galaxy.SolarSystems [solarSystemID];

		// Spawn a graphic for each object in the solar system.
		for (int i = 0; i < solarSystem.Children.Count; i++) {
			//Orbital o = solarSystem.Children [i];
			MakeSpritesForOrbital(this.transform, solarSystem.Children[i]);

		}

	}
	void MakeSpritesForOrbital(Transform transformParent, Orbital o) {
		GameObject go = new GameObject ();
		orbitalGameObjectMap [o] = go;
		go.transform.SetParent (transformParent);

		if (transformParent.name.ToString () == "SolarSystemView") {
			Rigidbody2D rig = go.AddComponent<Rigidbody2D>();
			rig.mass = 10000;
			rig.gravityScale = 0;
			go.AddComponent<SunGravity>();
		}

		// Set our position.
		go.transform.position = o.Position / zoomLevels;

		SpriteRenderer sr =  go.AddComponent<SpriteRenderer> ();
		sr.sprite = Sprites[o.GraphicID];

		// Recurses down to the orbital's children.
		for (int i = 0; i < o.Children.Count; i++) {
			MakeSpritesForOrbital(go.transform, o.Children[i]);
		}
	}
	void UpdateSprites (Orbital o) {
		GameObject go = orbitalGameObjectMap [o];
		if (go.transform.parent.name == "SolarSystemView") {
			go.name = "Sun";
		} else {
			string type = o.GetType().ToString();
			go.name = type + " ( " + go.transform.position.x + ", " + go.transform.position.y + ")";
		}

		go.transform.position = o.Position / zoomLevels;
		go.transform.rotation = o.Rotation;


//		float AngleRad = Mathf.Atan2(
//			Target.transform.position.y - Entity.transform.position.y,
//			Target.transform.position.x - Entity.transform.position.x
//		);
//		// Get Angle in Degrees
//		float AngleDeg = (180 / Mathf.PI) * AngleRad;
//		// Rotate Object
//		this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

		for (int i = 0; i < o.Children.Count; i++) {
			UpdateSprites(o.Children[i]);
		}

	}

	// Update is called once per frame
	void Update () {

		//
		for (int i = 0; i < solarSystem.Children.Count; i++) {
			//Orbital o = solarSystem.Children [i];
			UpdateSprites(solarSystem.Children[i]);

		}

	}
}
