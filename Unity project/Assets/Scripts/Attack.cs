using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    private int damage;
    public float DAMAGE_STRENGTH = 0.05f;

    public int getDamage()
    {
        return damage;
    }
    
    public void calculateDamage() 
    {
        damage += damage * ((int) DAMAGE_STRENGTH);
    }
}
