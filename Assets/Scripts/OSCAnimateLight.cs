using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Light))]


public class OSCAnimateLight : OSCAnimation {

	private Light l;

	float map(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}

	public enum LIGHT_FIELDS
	{
		Color_R,
		Color_G,
		Color_B,
		Range,
		Intensity,
	}

	public LIGHT_FIELDS fieldToAnimate;

	// Use this for initialization
	void Start () {

		l = this.GetComponent<Light>();

	}

	// Update is called once per frame
	void Update () {

		if (newMessage) {

			try
			{

				Color prevColor;

				switch (fieldToAnimate) {

				case LIGHT_FIELDS.Color_R:
					prevColor = l.color;
					prevColor.r = float.Parse(localMsg.Values[0].ToString());
					l.color = prevColor;
					break;

				case LIGHT_FIELDS.Color_G:
					prevColor = l.color;
					prevColor.g = float.Parse(localMsg.Values[0].ToString());
					l.color = prevColor;
					break;

				case LIGHT_FIELDS.Color_B:
					prevColor = l.color;
					prevColor.b = float.Parse(localMsg.Values[0].ToString());
					l.color = prevColor;
					break;

				case LIGHT_FIELDS.Intensity:

					float raw = float.Parse(localMsg.Values[0].ToString());
//					Debug.Log("Raw:" + raw);
					l.intensity = map(raw, 0.0f, 1.0f, 0.0f, 10.0f);
					break;

				case LIGHT_FIELDS.Range:
					l.range = float.Parse(localMsg.Values[0].ToString());
					break;

				default:
					break;
				}
				

			}
			catch (System.Exception e)
			{
				Debug.Log ("Wrong propertyname, or missing component, or type mismatch between message value and property value");
			}

			Debug.Log("newMessage False");
			newMessage = false;

		}

	}
}
