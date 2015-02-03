using UnityEngine;
using System.Collections;

public class ClientNetworkManager : MonoBehaviour {

    public string MASTERSERVER_IP = "127.0.0.1";
    public int MASTERSERVER_PORT = 23466;
    public string NAT_FACILITATOR_IP = "127.0.0.1";
    public int NAT_FACILITATOR_PORT = 50005;

    private HostData[] hostList;

    void Start()
    {
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

    private void refreshHostList()
    {
        MasterServer.RequestHostList("DreamBaker");
    }

    public void OnMasterServerEvent(MasterServerEvent masterServerEvent)
    {
        if (masterServerEvent == MasterServerEvent.HostListReceived)
        {
            hostList = MasterServer.PollHostList();
        }
    }

    private void joinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }

    public void OnConnectedToServer()
    {
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
        {
            refreshHostList();
        }
        if (hostList != null)
        {
            for (int i = 0; i < hostList.Length; i++)
            {
                if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
                    joinServer(hostList[i]);
            }
        }
        
    }

}
