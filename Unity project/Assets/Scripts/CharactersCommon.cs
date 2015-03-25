using UnityEngine;
using System.Collections;

public class CharactersCommon : MonoBehaviour {

    private float MAX_HOPE = 100;
    public float hopeBar;
    private float nextRespawnHopeLevel; 
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        hopeBar = MAX_HOPE;
    }

    public void takeDamage(float attackDamage)
    {
        hopeBar -= attackDamage;
        if (hopeBar <= 0)
        {
            dead(); 
        }
    }

    private void dead()
    {
        gameController.respawn();
    }

    public void setRespawnHopeLevel()
    {
        nextRespawnHopeLevel = MAX_HOPE;
    }

    public void respawnHopeLevel()
    {
        hopeBar = nextRespawnHopeLevel;
    }
}
