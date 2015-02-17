using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {

    public NetworkPlayer myPlayer;
    public GameObject playerAsset;


    [RPC]
    private void spawnPlayer(NetworkPlayer player)
    {
        GameObject newPlayer = Network.Instantiate(playerAsset, transform.position, transform.rotation, 0) as GameObject;
        if (player == myPlayer)
        {
            enableCamera(newPlayer.networkView.viewID);
        }
        else
        {
            networkView.RPC("enableCamera", player, newPlayer.networkView.viewID);
        }
    }

    [RPC]
    public void enableCamera(NetworkViewID playerID)
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player.networkView.viewID == playerID) // the one we juste created
            {
                player.GetComponent<Movement>().haveControl = true;
                Transform myCamera = player.transform.Find("Camera");
                myCamera.camera.enabled = true;
                myCamera.camera.GetComponent<AudioListener>().enabled = true;
                break;
            }
        }
    }

}
