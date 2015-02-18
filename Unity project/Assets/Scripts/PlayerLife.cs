using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public float healthBar = 100;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void takeDamage(float attackDamage)
    {
        healthBar -= attackDamage;
        if (healthBar <= 0)
        {
            gameController.respawn();
        }
    }
}
