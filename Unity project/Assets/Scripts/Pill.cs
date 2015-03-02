using UnityEngine;
using System.Collections;

public class Pill : MonoBehaviour
{
    public GameController gameController;

	void OnTriggerEnter(Collider collider) {
		if(collider.CompareTag("Player")) {
            collider.SendMessage("collectPill");
            Destroy(gameObject);
		}
	}
}
