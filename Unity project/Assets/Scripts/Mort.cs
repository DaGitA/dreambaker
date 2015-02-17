using UnityEngine;
using System.Collections;

public class Mort : MonoBehaviour {

    public void mort(GameObject gameObject)
    {
        Network.Destroy(gameObject);
    }
}
