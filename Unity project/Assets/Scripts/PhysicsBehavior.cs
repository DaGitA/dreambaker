using UnityEngine;
using System.Collections;

public class PhysicsBehavior : MonoBehaviour {

    public float gravity = 40;

    void Start()
    {
        Physics.gravity = new Vector3(0,-1 * gravity, 0);
    }
}
