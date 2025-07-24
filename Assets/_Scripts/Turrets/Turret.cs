using System.Collections.Generic;
using UnityEngine;

namespace CannonGame
{
    public class Turret : MonoBehaviour
    {
        [Header("Targeting")]
        [SerializeField] float checkRadius;
        [SerializeField] LayerMask checkMask;
        GameObject targetEnemy;
        [SerializeField] float targetUpdateRate;

        [Header("Shooting")]
        [SerializeField] GameObject bullet;
        [SerializeField] Transform shootPoint;
        [SerializeField] float fireRate;

        [Header("General")]
        [SerializeField] Animator anim;

        float nextTimeToFire;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Invoke("UpdateTarget", 1 / targetUpdateRate);
        }

        // Update is called once per frame
        void Update()
        {
            if(targetEnemy == null)
            {
                return;
            }

            Vector2 direction = (targetEnemy.transform.position - transform.position).normalized;
            transform.up = direction;

            if(Time.time > nextTimeToFire)
            {
                GameObject spawnedBullet = Instantiate(bullet, shootPoint.position, transform.rotation);
                nextTimeToFire = Time.time + 1 / fireRate;
                anim.SetTrigger("Shoot");
            }

        }

        void UpdateTarget()
        {
            Collider2D[] nearbyEnemies = Physics2D.OverlapCircleAll(transform.position, checkRadius, checkMask);
            //massive number so enemy distances can be smaller
            float closestDistance = 9999;
            GameObject closestEnemy = null;
            foreach (Collider2D enemy in nearbyEnemies)
            {
                if (Vector2.Distance(transform.position, enemy.transform.position) < closestDistance)
                {
                    closestDistance = Vector2.Distance(transform.position, enemy.transform.position);
                    closestEnemy = enemy.gameObject;
				}
            }
            targetEnemy = closestEnemy;
			Invoke("UpdateTarget", 1 / targetUpdateRate);
		}

		private void OnDrawGizmosSelected()
		{
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, checkRadius);
		}
	}
}
