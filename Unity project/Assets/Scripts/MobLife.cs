using UnityEngine;
using System.Collections;

public class MobLife : MonoBehaviour {

    public float healthBar = 100;
    private GameObject gameController;

    void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    public void takeDamage(float attackDamage)
    {
        healthBar -= attackDamage;
        Debug.Log(healthBar);
        if (healthBar < 0)
        {
            gameController.SendMessage("mort", gameObject);
        }
    }
}
