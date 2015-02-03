using UnityEngine;
using System.Collections.Generic;

public class PreGameNetworkManager : MonoBehaviour {

    public List<NetworkPlayer> players = new List<NetworkPlayer>();


    [RPC]
    private void refreshPlayerList(List<NetworkPlayer> players)
    {
        this.players.Clear();
        foreach (NetworkPlayer player in players)
        {
            this.players.Add(player);
        }
    }

}
