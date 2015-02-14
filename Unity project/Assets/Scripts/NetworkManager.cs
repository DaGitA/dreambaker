using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetworkManager : MonoBehaviour {


    public GameObject playerAsset;
	private const string gameTypeName = "DreamBakerGame";
	public string gameName = "";
	private HostData[] hostList;
    public NetworkPlayer myPlayer;

    public string MASTERSERVER_IP = "127.0.0.1";
    public int MASTERSERVER_PORT = 23466;
    public int NAT_FACILITATOR_PORT = 50005;

	public void startServer(){
		Network.InitializeServer (4, 25003, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameTypeName, gameName);
		//refreshHostList ();
        gameNameEntered();
	}

	void OnServerInitialized(){
		Debug.Log("Server Initialized");
        if (Network.isServer)
        {
            myPlayer = Network.player;
            spawnPlayer(myPlayer);
        }
	}

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

	public void joinServer(){
		Network.Connect (hostList [0]);
        gameNameEntered();
	}

	private void joinServer(HostData hostData){
		Network.Connect (hostData);
	}

	void OnConnectedToServer(){
		Debug.Log ("Server Joined");
        myPlayer = Network.player;
        networkView.RPC("spawnPlayer", RPCMode.Server, myPlayer);
	}

	public void refreshHostList(){
		MasterServer.RequestHostList (gameTypeName);
	}

	void OnMasterServerEvent(MasterServerEvent serverEvent){
		Debug.Log(serverEvent.ToString());
		if (serverEvent == MasterServerEvent.HostListReceived) {
			hostList = MasterServer.PollHostList();
		}
	}

	void Start(){
        initializeMasterServer();
        initializeFacilitator();
        refreshHostList();
    }

    private void initializeMasterServer()
    {
        MasterServer.ipAddress = MASTERSERVER_IP;
        MasterServer.port = MASTERSERVER_PORT;
    }

    private void initializeFacilitator()
    {
        Network.natFacilitatorIP = MASTERSERVER_IP;
        Network.natFacilitatorPort = NAT_FACILITATOR_PORT;
    }

    public void gameNameEntered()
    {
        GameObject gameNameInputField = GameObject.Find("GameNameInputField");
        gameName = gameNameInputField.GetComponent<InputField>().text;
        if (hostList != null)
        {
            for (int i = 0; i < hostList.Length; i++)
            {
                    joinServer(hostList[i]);
            }
        }
    }
	
}
