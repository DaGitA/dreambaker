using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string gameTypeName = "DreamBakerGame";
	private const string gameName = "CoolRoom";
	private HostData[] hostList;
	private Text hostListText;

	public void startServer(){
		Network.InitializeServer (4, 25003);
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
		hostListText = GetComponent<Text> ();
		refreshHostList ();
	}

	
	
	
	
}
