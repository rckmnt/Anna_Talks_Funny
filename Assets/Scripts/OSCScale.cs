using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Light))]
public class OSCScale : OSCAnimation {

	private GameObject obj;


	// Use this for initialization
	void Start () {

		obj = this.GetComponent<GameObject>();

	}

	// Update is called once per frame
	void Update () {

		Debug.Log ("Scale is updating");

		if (newMessage) {

			float size = float.Parse(localMsg.Values[0].ToString());
			Debug.Log ("Size Scott: " + size);
			obj.transform.localScale = new Vector3(size * 4.0f, size * 4.0f, size * 4.0f);

			transform.localScale = new Vector3(size * 4.0f, size * 4.0f, size * 4.0f);

		}

	}
}
