using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
   
    [RPC]
    private void loadScene(string levelName, int levelPrefix)
    {
        Network.SetSendingEnabled(0, false);
        Network.isMessageQueueRunning = false;

        Network.SetLevelPrefix(levelPrefix);
        Application.LoadLevel(levelName);

        Network.isMessageQueueRunning = true;
        Network.SetSendingEnabled(0, true);

    }
}
