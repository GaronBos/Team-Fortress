using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster1nav : MonoBehaviour
{
   public NavMeshAgent navAgent; //will detect the nav mesh and move along it 
   public GameObject currentTarget;

    bool inBattle;

    // use this ofr instantiating
    void Start()
    {
        inBattle = false;

        currentTarget = GameObject.FindGameObjectWithTag("Enemy");
        navAgent = gameObject.GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(currentTarget.transform.position, transform.gameObject.transform.position) < 5)
        {
            inBattle = true;
        }

        if (inBattle)
        {
            navAgent.destination = currentTarget.transform.position;
        }
    }
}
