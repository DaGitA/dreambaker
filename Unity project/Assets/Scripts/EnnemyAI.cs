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
    public float maximalDistanceToPursueTarget;
    public float minimalDistanceAtWichStopPursuingTarget;
    public int attackStrenght;
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
        if (canPursue())
        {
            moveTowardTarget();
        }
        else if (tooFar())
        {
            transform.position = positionOrigine;
            transform.rotation = rotationOrigine;
        }
        else
        {
            if ((Time.time - lastAttack) >= attackDelay)
            {
                attack();                
            }
        }

    }

    private bool tooFar()
    {
         float distanceBetweenEnnemyAndTarget = Vector3.Distance(cible.position, transform.position);
         if (distanceBetweenEnnemyAndTarget > maximalDistanceToPursueTarget)
             return true;
         else
             return false;           
    }

    private void attack()
    {
        hopeLevelSlider.value = (hopeLevelSlider.value - attackStrenght);
        lastAttack = Time.time;
    }

    private bool canPursue()
    {
        float distanceBetweenEnnemyAndTarget = Vector3.Distance(cible.position, transform.position);

        if (distanceBetweenEnnemyAndTarget < maximalDistanceToPursueTarget && distanceBetweenEnnemyAndTarget > minimalDistanceAtWichStopPursuingTarget)
            return true;
        else
            return false;
    }

    private void moveTowardTarget()
    {
        transform.LookAt(cible.position);
        transform.position += transform.forward * vitesseObjet * Time.deltaTime;
    }



}