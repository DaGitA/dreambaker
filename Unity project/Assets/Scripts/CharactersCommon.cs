using UnityEngine;
using System.Collections;

public class CharactersCommon : MonoBehaviour {

    private float MAX_HOPE = 100;
    public float hopeBar;
    private float nextRespawnHopeLevel; 
    private GameController gameController;
    private HopeSliderController hopeSliderController;
    private GameObject hopeSlider;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        hopeSlider = GameObject.Find("LifeSlider");
        hopeSliderController = hopeSlider.GetComponent<HopeSliderController>();
        hopeBar = MAX_HOPE;
    }

    public void takeDamage(float attackDamage)
    {
        hopeBar -= attackDamage;
        Debug.Log(hopeBar);
        if (hopeBar <= 0)
        {
            dead(); 
        }
        hopeSliderController.updateHopeLevel(hopeBar);
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
