using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBall : MonoBehaviour
{
    public Transform SpellSpawn;
    public GameObject FireSpell;
    public InputActionReference toggleReference = null;
    //public GameObject[] PlayerSpellsToInstantiate;

    private void Awake()
    {
        toggleReference.action.started += Toggle;
    }
    
    void Update()
    {
        transform.position = SpellSpawn.position;
    }


    private void OnDestroy()
    {
        toggleReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        //int n = Random.Range(0,PlayerSpellsToInstantiate.Length);
        //GameObject S = Instantiate(PlayerSpellsToInstantiate[n], SpellSpawn.position, SpellSpawn.rotation);
        Instantiate(FireSpell,transform.position,transform.rotation);
        
    }


    private void Start()
    {
        
    }

}
