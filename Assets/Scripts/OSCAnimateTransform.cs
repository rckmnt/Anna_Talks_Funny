using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCAnimateTransform : OSCAnimation {

	private Transform t;

	float map(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}


	public enum TRANSFORM_FIELDS
	{
		Position_X,
		Position_Y,
		Position_Z,
		Rotation_X,
		Rotation_Y,
		Rotation_Z,
		Scale_X,
		Scale_Y,
		Scale_Z
	}

	public TRANSFORM_FIELDS fieldToAnimate;

	// Use this for initialization
	void Start () {

		t = this.GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log("Updating AnimateTransform!" );


		if (newMessage) {
			Debug.Log("New Message triggered! " );
			try
			{

				Vector3 pos;

				switch (fieldToAnimate) {

				case TRANSFORM_FIELDS.Position_X:
					pos = t.position;
					pos.x = float.Parse(localMsg.Values[0].ToString());
					t.position = pos;
					break;
				
				case TRANSFORM_FIELDS.Position_Y:
					pos = t.position;
					pos.y = float.Parse(localMsg.Values[0].ToString());
					t.position = pos;
					break;

				case TRANSFORM_FIELDS.Position_Z:
					pos = t.position;
					pos.z = float.Parse(localMsg.Values[0].ToString());
					t.position = pos;
					break;

				case TRANSFORM_FIELDS.Rotation_X:
					pos = t.eulerAngles;
					pos.x = float.Parse(localMsg.Values[0].ToString());
					t.eulerAngles = pos;
					break;
				
				case TRANSFORM_FIELDS.Rotation_Y:
					pos = t.eulerAngles;
					pos.y = float.Parse(localMsg.Values[0].ToString());
					t.eulerAngles = pos;
					break;
				
				case TRANSFORM_FIELDS.Rotation_Z:
					pos = t.eulerAngles;
					pos.z = float.Parse(localMsg.Values[0].ToString());
					t.eulerAngles = pos;
					break;

				case TRANSFORM_FIELDS.Scale_X:
					pos = t.localScale;
					pos.x = float.Parse(localMsg.Values[0].ToString());
					t.localScale = pos;
					break;


				case TRANSFORM_FIELDS.Scale_Y:
					pos = t.localScale;
					float raw = float.Parse(localMsg.Values[0].ToString());
					Debug.Log("Y transform:" + raw);
					pos.y = map(raw, 0.0f, 1.0f, 0.5f, 10.0f);
					Debug.Log(pos.y);
					t.localScale = pos;
					break;

				case TRANSFORM_FIELDS.Scale_Z:
					pos = t.localScale;
					pos.z = float.Parse(localMsg.Values[0].ToString());
					t.localScale = pos;
					break;

				default:
					break;
				}


			}
			catch (System.Exception e)	
			{
				Debug.Log ("Wrong propertyname, or missing component, or type mismatch between message value and property value");
			}

			newMessage = false;

		}
		
	}
}
