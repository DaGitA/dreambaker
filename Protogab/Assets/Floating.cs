using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour
	{
		public float intensiteDeRotation;

		void Update ()
		{
			transform.Rotate(Time.deltaTime,intensiteDeRotation,intensiteDeRotation);
		}
	}
