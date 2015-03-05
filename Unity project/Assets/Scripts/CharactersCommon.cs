using UnityEngine;
using System.Collections;

public class CharactersCommon : MonoBehaviour {

    private float MAX_HOPE = 100;
    public float hopeBar;
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
}
