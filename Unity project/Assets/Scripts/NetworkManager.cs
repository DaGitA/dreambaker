using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string gameTypeName = "DreamBakerGame";
	private const string gameName = "CoolRoom";
	private HostData[] hostList;

	public void startServer(){
		Network.InitializeServer (2, 25000, !Network.HavePublicAddress ());
		MasterServer.RegisterHost (gameTypeName, gameName);
	}

	void OnServerInitialized(){
		Debug.Log("Server Initialized");
	}
	
	public void joinServer(HostData hostData){
		Network.Connect (hostData);
	}

	void OnConnectedServer(){
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
		refreshHostList ();
	}
	


}
