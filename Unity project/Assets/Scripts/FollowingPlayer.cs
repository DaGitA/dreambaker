using UnityEngine;
using System.Collections;

public class FollowingPlayer : MonoBehaviour {

	//------------Variables----------------//
	public Transform cible;
	public int vitesseObjet;
	public int distanceMaximalePourPoursuivreCible;
	public int distanceMinimalePourArreterPoursuite;
	private Vector3 positionOrigine;
	private Quaternion rotationOrigine;

	//------------------------------------//    
	
	void Awake()
	{
		positionOrigine = transform.position;
		rotationOrigine = transform.rotation;
	}
	
	
	void Start ()
	{
	}
	

	void Update ()
	{

		if (Vector3.Distance (cible.position, transform.position) < distanceMaximalePourPoursuivreCible && Vector3.Distance (cible.position, transform.position) > distanceMinimalePourArreterPoursuite) {

			//Move towards target
			transform.LookAt (cible.position);     
			transform.position += transform.forward * vitesseObjet * Time.deltaTime;
		}
		else if(Vector3.Distance (cible.position, transform.position) > distanceMaximalePourPoursuivreCible){

			transform.position = positionOrigine;
			transform.rotation = rotationOrigine;
		}

	}


}   

