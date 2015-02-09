using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MobsDamages : MonoBehaviour {

    public int mobLife;
    public int initialMobLife;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void takeDamage(Attack attackOnMob){
        mobLife = mobLife - attackOnMob.getDamage();
    }

}
