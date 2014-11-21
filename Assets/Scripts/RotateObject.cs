using UnityEngine;
using System.Collections;

public enum RotationTypes {
	Clockwise,
	CounterClockwise
}

public enum Axis {
	x,
	y,
	z,
}

public class RotateObject : MonoBehaviour
{
		public float speed = 0;
		public Axis axis = Axis.x;
		public RotationTypes type = RotationTypes.Clockwise;

		// Use this for initialization
		void Start ()
		{
			if (type == RotationTypes.CounterClockwise) {
				speed = -speed;
			}
		}
	
		// Update is called once per frame
		void Update ()
		{
			switch (axis) {
				case Axis.x: 
					transform.Rotate (0, 0 , speed * Time.deltaTime);
					break;
				case Axis.y: 
					transform.Rotate (0, speed * Time.deltaTime, 0);
					break;
				case Axis.z: 
					transform.Rotate (speed * Time.deltaTime, 0, 0);
					break;
				default: break;
			}
		}
}

