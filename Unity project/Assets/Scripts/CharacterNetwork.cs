using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NetworkView))]
public class CharacterNetwork : MonoBehaviour {

    public GameObject caracterPrefab;
    public NetworkPlayer owner;


    public GameObject map;
    private bool mapLoaded;

    [RPC]
    public void Awake()
    {
        mapLoaded = false;
    }
    
    [RPC]
    public void startGame()
    {
        if (!mapLoaded)
        {
            loadMap();
        }
        spawnPlayer(Network.player);
    }

    [RPC]
    private void spawnPlayer(NetworkPlayer player)
    {
        GameObject newPlayer = Network.Instantiate(caracterPrefab, transform.position, transform.rotation, 0) as GameObject;
        newPlayer.networkView.RPC("setOwner", RPCMode.AllBuffered, player);
    }

    [RPC]
    private void loadMap()
    {
        Network.Instantiate(map, Vector3.zero, Quaternion.identity, 0);
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }

}
