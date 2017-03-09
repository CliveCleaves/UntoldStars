using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour {

	public float parralax = 2f;

	public bool back = false;
	MeshRenderer mr;
	Material mat;

	void Start () {
		mr = GetComponent<MeshRenderer> ();
		mat = mr.material;

		if (back == true) {
			Vector2 scale = mat.mainTextureScale;
			Vector2 change = new Vector2 (scale.x * 2, scale.y * 2);
			mat.mainTextureScale = change;
		}
	}
	
	// Update is called once per frame
	void Update () {
		mr = GetComponent<MeshRenderer> ();
		mat = mr.material;
		Vector2 offset = mat.mainTextureOffset;
		offset.x = transform.position.x / transform.localScale.x / parralax;
		offset.y = transform.position.y / transform.localScale.y / parralax;

		mat.mainTextureOffset = offset;
	}
}
