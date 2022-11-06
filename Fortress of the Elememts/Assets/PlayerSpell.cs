using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpell : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] PlayerSpellsToInstantiate;

    public void GetASpell()
    {
        int n = Random.Range(0,PlayerSpellsToInstantiate.Length);
        GameObject S = Instantiate(PlayerSpellsToInstantiate[n], spawnPoint.position, spawnPoint.rotation);
    }

}
