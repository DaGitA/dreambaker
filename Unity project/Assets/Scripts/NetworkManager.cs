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
    public string NAT_FACILITATOR_IP = "127.0.0.1";
    public int NAT_FACILITATOR_PORT = 50005;

	private void startServer(){
		Network.InitializeServer (4, 25003, !Network.HavePublicAddress());
		MasterServer.RegisterHost (gameTypeName, gameName);
		//refreshHostList ();
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
	}

	private void joinServer(HostData hostData){
		Network.Connect (hostData);
	}

	void OnConnectedToServer(){
		Debug.Log ("Server Joined");
        myPlayer = Network.player;
        networkView.RPC("spawnPlayer", RPCMode.Server, myPlayer);
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
        Network.natFacilitatorIP = NAT_FACILITATOR_IP;
        Network.natFacilitatorPort = NAT_FACILITATOR_PORT;
    }

    void OnGUI()
    {
        if (Network.isClient || Network.isServer)
        {
            return;
        }
        else
        {
            if (gameName == "")
            {
                GUI.Label(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 2 - Screen.height / 20, Screen.width / 5, Screen.height / 20), "Game Name");
            }
            gameName = GUI.TextField(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 2 - Screen.height / 20, Screen.width / 5, Screen.height / 20), gameName, 25);
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 2, Screen.width / 5, Screen.height / 10), "Create New Server"))
            {
                startServer();
            }
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.width / 10, Screen.height / 2 + Screen.height / 10, Screen.width / 5, Screen.height / 10), "Find Server"))
            {
                refreshHostList();
            }
            if (hostList != null)
            {
                for (int i = 0; i < hostList.Length; i++)
                {
                    if(GUI.Button(new Rect(Screen.width/2 - Screen.width/10, Screen.height/2 + ((Screen.height/20)*(i+4)),Screen.width/5, Screen.height/20),hostList[i].gameName))
                    {
                        joinServer(hostList[i]);
                    }
                }
            }
        }
    }
	
	
	
	
}
