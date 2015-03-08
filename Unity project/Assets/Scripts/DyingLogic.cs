using UnityEngine;
using System.Collections;

public class DyingLogic : MonoBehaviour {

    public void mort(GameObject gameObject)
    {
        Debug.Log("passe ici");
        Network.Destroy(gameObject);
    }
}
