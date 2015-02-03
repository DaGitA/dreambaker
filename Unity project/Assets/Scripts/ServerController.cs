using UnityEngine;
using System.Collections.Generic;

public class ServerController : MonoBehaviour {

    public List<NetworkPlayer> players = new List<NetworkPlayer>();

    public string MASTERSERVER_IP = "127.0.0.1";
    public int MASTERSERVER_PORT = 23466;
    public string NAT_FACILITATOR_IP = "127.0.0.1";
    public int NAT_FACILITATOR_PORT = 50005;

    private int levelPrefix = 0;

    void Start()
    {
        initialize();
        registerServer();
    }

    private void initialize()
    {
        initializeMasterserver();
        initializeFacilitator();
        Network.InitializeServer(4,23467,!Network.HavePublicAddress());
    }

    private void OnServerInitialized()
    {
        Debug.Log("Server Initializied");
    }

    private void initializeMasterserver()
    {
        MasterServer.ipAddress = MASTERSERVER_IP;
        MasterServer.port = MASTERSERVER_PORT;
    }

    private void initializeFacilitator()
    {
        Network.natFacilitatorIP = NAT_FACILITATOR_IP;
        Network.natFacilitatorPort = NAT_FACILITATOR_PORT;
    }

    private void registerServer()
    {
        MasterServer.RegisterHost("DreamBaker", "GLO_Room");
    }

    public void OnPlayerConnected(NetworkPlayer player)
    {
        players.Add(player);
        networkView.RPC("loadScene", player, "Antichambre", levelPrefix);
    }

    void OnPlayerDisconnected(NetworkPlayer player) {
        players.Remove(player);
        Debug.LogError("YARHH");
    }

    

}
