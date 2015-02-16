using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetworkManager : MonoBehaviour {


	private const string gameTypeName = "DreamBakerGame";
	private string gameName = "myGameName";
	private HostData[] hostList;

    public string MASTERSERVER_IP = "127.0.0.1";
    public int MASTERSERVER_PORT = 23466;
    public int NAT_FACILITATOR_PORT = 50005;

	private void startServer(){
		Network.InitializeServer (4, 25003, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameTypeName, gameName);
		//refreshHostList ();
	}

	void OnServerInitialized(){
		Debug.Log("Server Initialized");
	}

	public void joinServer(){
		Network.Connect (hostList [0]);
	}

	private void joinServer(HostData hostData){
		Network.Connect (hostData);
	}

	void OnConnectedToServer(){
		Debug.Log ("Server Joined");
	}

	private void refreshHostList(){
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
}
