using UnityEngine;
using System.Collections;

[RequireComponent(typeof (NetworkView))]
public class CharacterNetwork : MonoBehaviour {

    public GameObject caracterPrefab;
    public NetworkPlayer owner;


    [RPC]
    public void startGame()
    {
        spawnPlayer(Network.player);
    }

    [RPC]
    private void spawnPlayer(NetworkPlayer player)
    {
        GameObject newPlayer = Network.Instantiate(caracterPrefab, transform.position, transform.rotation, 0) as GameObject;
        newPlayer.GetComponent<NetworkView>().RPC("setOwner", RPCMode.AllBuffered, player);
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }

}
