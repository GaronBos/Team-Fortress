using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1Battle : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navAgent;
    bool knockBack;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        knockBack = false;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (knockBack)
        {
            navAgent.velocity = direction * 8; //knocks enemy back when appropiate
        }
    }

    IEnumerator KnockBack()
    {
        knockBack = true;
        navAgent.speed = 10;
        navAgent.angularSpeed = 0;
        navAgent.acceleration = 20;

        yield return new WaitForSeconds(0.2f); // only knock the enemy back for a short time 

        //reset to the default settings
        knockBack = false;
        navAgent.speed = 4;
        navAgent.angularSpeed = 180;
        navAgent.acceleration = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        direction = other.transform.forward;
        if (other.name.Equals("BobAttack(clone)")) { StartCoroutine(KnockBack()); Destroy(other.gameObject); }
    }
}
