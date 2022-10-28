using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 20;
        public GameObject Enemy;
        public Health EnemyHP;
        private Vector3 FiringPoint;

        [SerializeField]
        private float ProjectileSpeed;

        [SerializeField]
        private float maxProjectileDistance;

        void Start()
        {
            FiringPoint = transform.position;
            EnemyHP = Enemy.GetComponent<Health>();
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

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Enemy")
        {
            if(collisionGameObject.GetComponent<Health>() != null)
            {
                collisionGameObject.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
            }


        }
    }
}