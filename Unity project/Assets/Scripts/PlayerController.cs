using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed = 5;
    public float RotateSpeed = 80;
    
    // Use this for initialization    
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        float MoveForward = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
        float MoveRotate = Input.GetAxis("Horizontal") * RotateSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * MoveForward);
        transform.Rotate(Vector3.up * MoveRotate);
	}
}
