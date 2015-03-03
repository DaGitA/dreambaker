using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : MonoBehaviour {

    public WeaponAttackBehaviour weaponPrefab;
    public bool isOnCoolDown = false;

    void Start()
    {
        weaponPrefab = this.GetComponentInChildren<WeaponAttackBehaviour>();
    }

    void Update()
    {
        if (Input.GetButton("Fire2") && !isOnCoolDown)
        {
            weaponPrefab.gameObject.SetActive(true);
        }
        
    }

    void FixedUpdate()
    {
        weaponPrefab.gameObject.SetActive(false);
    }

    private void attack()
    {
        isOnCoolDown = true;
        GameObject weapon = Instantiate(weaponPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
        weapon.transform.parent = gameObject.transform;
        weapon.transform.position = new Vector3(0, 0, 0);
        Debug.Log("Attaqueee");
    }
}
