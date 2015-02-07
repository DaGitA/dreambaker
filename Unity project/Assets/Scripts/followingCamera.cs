using UnityEngine;
using System.Collections;

public class followingCamera : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start () {
		/*Vector3 temp = transform.position;
 temp.x += 10;
 
 transform.position = temp;*/
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 temp = transform.position;
		temp.z = target.position.z;
		transform.position = temp;
	}
}
