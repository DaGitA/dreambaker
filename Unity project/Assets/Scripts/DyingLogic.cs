using UnityEngine;
using System.Collections;

public class DyingLogic : MonoBehaviour {

    public void mort(GameObject gameObject)
    {
        Network.Destroy(gameObject);
    }
}
