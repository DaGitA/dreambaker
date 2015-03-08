using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NetworkView))]
public class CharacterNetwork : MonoBehaviour
{

    private string caracterPrefabChoice;
    private GameObject caracterPrefab;
    public NetworkPlayer owner;

    public GameObject map;
    private GameObject gameController;
    private string DEFAULT_PLAYER = "Prefabs/PlayerOne";
    private bool gameHasStarted;
    private string GAMECONTROLLER_PATH = "Prefabs/GameController";
    private UIController uIController;

    [RPC]
    void Start()
    {
        caracterPrefabChoice = DEFAULT_PLAYER;
        gameHasStarted = false;
        gameController = Resources.Load(GAMECONTROLLER_PATH) as GameObject;
        uIController = GameObject.Find("UICanvas").GetComponent<UIController>();
    }

    [RPC]
    public void startGame()
    {
        if (gameHasStarted == false)
        {
            if (Network.isServer)
            {
                networkView.RPC("setGameAsStarted", RPCMode.All);
                loadGameController();
                loadMap();
                spawnPlayer();
                networkView.RPC("startGame", RPCMode.Others);
                uIController.prepareUIForGameBeginning();
            }
            else
            {
                networkView.RPC("startGame", RPCMode.Server);
                uIController.prepareUIForGameBeginning();
            }
        }
        else
        {
            if (Network.isServer)
            {
            }
            else
            {
                spawnPlayer();
            }
        }
    }

    [RPC]
    private void loadGameController()
    {
        Network.Instantiate(gameController, Vector3.zero, Quaternion.identity, 0);
    }

    [RPC]
    private void spawnPlayer()
    {
        NetworkPlayer player = Network.player;
        caracterPrefab = Resources.Load(caracterPrefabChoice) as GameObject;
        GameObject newPlayer = Network.Instantiate(caracterPrefab, transform.position, transform.rotation, 0) as GameObject;
        newPlayer.networkView.RPC("setOwner", RPCMode.AllBuffered, player);
    }

    [RPC]
    private void loadMap()
    {
        Network.Instantiate(map, Vector3.zero, Quaternion.identity, 0);
    }

    void OnPlayerDisconnected(NetworkPlayer player)
    {
        Network.RemoveRPCs(player);
        Network.DestroyPlayerObjects(player);
    }

    public void choosePlayerOne()
    {
        caracterPrefabChoice = "Prefabs/PlayerOne";
    }

    public void choosePlayerTwo()
    {
        caracterPrefabChoice = "Prefabs/PlayerTwo";
    }

    [RPC]
    public void setGameAsStarted()
    {
        gameHasStarted = true;
    }
}
