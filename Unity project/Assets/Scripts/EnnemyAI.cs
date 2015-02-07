using UnityEngine;
using System.Collections;

public class EnnemyAI : MonoBehaviour
{

    //------------Variables----------------//
    
    public UnityEngine.UI.Text hopeLevelText;
    public UnityEngine.UI.Slider hopeLevelSlider;
    public float attackDelay;
    public Transform cible;
    public int vitesseObjet;
    public float distanceMaximalePourPoursuivreCible;
    public float distanceMinimalePourArreterPoursuite;
    private Vector3 positionOrigine;
    private Quaternion rotationOrigine;
    float lastAttack;
   

    //------------------------------------//    

    void Awake()
    {
        positionOrigine = transform.position;
        rotationOrigine = transform.rotation;
    }


    void Start()
    {
        
    }


    void Update()
    {
        
        if (Vector3.Distance(cible.position, transform.position) < distanceMaximalePourPoursuivreCible && Vector3.Distance(cible.position, transform.position) > distanceMinimalePourArreterPoursuite)
        {

            //Move towards target
            transform.LookAt(cible.position);
            transform.position += transform.forward * vitesseObjet * Time.deltaTime;
        }
        else if (Vector3.Distance(cible.position, transform.position) > distanceMaximalePourPoursuivreCible)
        {

            transform.position = positionOrigine;
            transform.rotation = rotationOrigine;
        }
        else
        {
            if ((Time.time - lastAttack) >= attackDelay)
            {

                hopeLevelSlider.value = (hopeLevelSlider.value - 1);
                hopeLevelText.text = (hopeLevelSlider.value - 1).ToString();
                lastAttack = Time.time;
                
            }
        }

    }



}