using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour
{

  public Transform target;
    public bool spellON;
    public bool castSpell;

   [SerializeField]
   private GameObject spellPrefab;
   [SerializeField]
    


    void Start()
    {
        castSpell = true;
        spellON = false;
        transform.position = target.position;
    }
   private void Update()
   {
    if(Input.GetKeyUp(KeyCode.Space))
    {
        Destroy(gameObject);
        spellON = false;
        castSpell = true;
    }
    if(!spellON && castSpell)
    {
        Spawn();
    }
    if(spellPrefab)
    {
        spellON = true; 
        castSpell = false;
    }
    else
    {
        spellON = false;
        castSpell = true;
    }
    

    
   }

   private void Spawn()
   {
    Instantiate(spellPrefab, transform.position, transform.rotation);
   }


    
}
