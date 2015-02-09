using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MobsDamages : MonoBehaviour {

    public int mobLife;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void takeDamage(Attack attackOnMob){
        mobLife = mobLife - attackOnMob.damage;
    }

}
