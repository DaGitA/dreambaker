using UnityEngine;
using System.Collections;

public class spawnArea : MonoBehaviour {
	public Transform mobs;
	public int spawned = 0;
	private float xMin;
	private float xMax;
	private float zMin;
	private float zMax;
	public int maxNumber = 30;
	private float canspawn = 5;
	public float delay = 5.0f;
	void Start() 
	{
		Renderer renderer = gameObject.GetComponent<Renderer>();
		float width = renderer.bounds.size.x;
		Renderer renderer2 = gameObject.GetComponent<Renderer>();
		float length = renderer2.bounds.size.z;
		xMin = transform.position.x - width/ 2;
		xMax = transform.position.x + width / 2;
		zMin = transform.position.z - length / 2;
		zMax = transform.position.z + length / 2;


	}
	void Update() {

		if (Time.time >= canspawn && spawned < maxNumber) 
		{
			
			Vector3 position = new Vector3(Random.Range(xMin, xMax), 1, Random.Range(zMin, zMax));
			Instantiate(mobs, position, Quaternion.identity);
			canspawn += delay;
			spawned++;
		}
		}
}
