using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NetworkView))]
public class CharacterNetwork : MonoBehaviour {

    public GameObject caracterPrefab;
    public NetworkPlayer owner;


    public GameObject map;
    public GameObject gameController;
    private bool mapLoaded;
    private bool gameControllerLoaded;
  
    [RPC]
    public void startGame()
    {
        if (Network.isServer)
        {
            loadGameController();
            loadMap();
        }
        spawnPlayer(Network.player);
    }

    [RPC]
    private void loadGameController()
    {
        gameControllerLoaded = true;
        Network.Instantiate(gameController, Vector3.zero, Quaternion.identity, 0);   
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
