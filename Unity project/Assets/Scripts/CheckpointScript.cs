using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour
{

    CheckPointController checkpointController;
    CrazinessLevelController crazinessLevelController;
    CharactersCommon player;
    GameObject gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        checkpointController = gameController.GetComponent<CheckPointController>();
        crazinessLevelController = gameController.GetComponent<CrazinessLevelController>();
        player = GameObject.FindWithTag("Player").GetComponent<CharactersCommon>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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
}
