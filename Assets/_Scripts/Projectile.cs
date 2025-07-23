using System.Collections;
using UnityEngine;

namespace CannonGame
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float launchSpeed = 10f;

        private Rigidbody2D _rigidbody2d;

        private void Awake()
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            _rigidbody2d.AddForce(transform.up * launchSpeed, ForceMode2D.Impulse);
            StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(3f);
            ObjectPoolManager.ReturnToPool(gameObject);
        }
    }
}
