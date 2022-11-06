using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnBall : MonoBehaviour
{
    public Transform SpellSpawn;
    public GameObject Spell;
    public InputActionReference toggleReference = null;

    private void Awake()
    {
        toggleReference.action.started += Toggle;
    }



    private void OnDestroy()
    {
        toggleReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {

        Instantiate(Spell,transform.position,transform.rotation);
        
    }


    private void Start()
    {
        transform.position = SpellSpawn.position;
    }

}
