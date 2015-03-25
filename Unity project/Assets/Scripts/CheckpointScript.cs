using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour
{

    CheckPointController checkpointController;
    CrazinessLevelController crazinessLevelController;
    CharactersCommon player;

    void Awake()
    {
        checkpointController = GameObject.Find("GameController").GetComponent<CheckPointController>();
        crazinessLevelController = GameObject.Find("GameController").GetComponent<CrazinessLevelController>();
        player = GameObject.FindWithTag("Player").GetComponent<CharactersCommon>();
    }

    public void OnTriggerEnter()
    {
        Debug.Log("CheckPoint entered");
        if (checkpointController.isNewCheckpoint(gameObject.GetInstanceID()))
        {
            checkpointController.setNextRespawnLocation(transform.position);
            crazinessLevelController.setNextRespawnCrazinessLevel();
            player.setRespawnHopeLevel();
        }
    }


}
