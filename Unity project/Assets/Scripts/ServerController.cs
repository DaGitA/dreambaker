using UnityEngine;
using System.Collections;

public class ServerController : MonoBehaviour {

    public GameObject playerPrefab;


    public string MASTERSERVER_IP = "127.0.0.1";
    public int MASTERSERVER_PORT = 23466;
    public string NAT_FACILITATOR_IP = "127.0.0.1";
    public int NAT_FACILITATOR_PORT = 50005;

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
        spawnPlayer();
    }

    public void OnPlayerDisconnected(NetworkPlayer player)
    {
        Destroy(gameObject);
    }

    private void spawnPlayer(){
        Network.Instantiate(playerPrefab,new Vector3(), Quaternion.identity, 0);
    }

}
