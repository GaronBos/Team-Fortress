using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piew : MonoBehaviour
{
    private Vector3 FiringPoint;

    [SerializeField]
    private float ProjectileSpeed;

    [SerializeField]
    private float maxProjectileDistance;

    void Start()
    {
        FiringPoint = transform.position;

    }

    void Update()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        if (Vector3.Distance(FiringPoint, transform.position) > maxProjectileDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * ProjectileSpeed * Time.deltaTime);
        }
    }
}
