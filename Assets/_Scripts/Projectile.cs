using System.Collections;
using UnityEngine;

namespace CannonGame
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float launchSpeed = 10f;

        [Header("Culling")]
        [SerializeField] private float visibilityChecksPerSecond = 10;
        [SerializeField] private float cullDelay = 0.5f;

        private Camera _camera;
        private Rigidbody2D _rigidbody2d;
        private Collider2D _collider2d;
        private TrailRenderer _trailRenderer;

        private WaitForSeconds _checkDelay;
        private WaitForSeconds _cullDelay; 

        private void Awake()
        {
            _camera = Camera.main;
            _rigidbody2d = GetComponent<Rigidbody2D>();
            _collider2d = GetComponent<Collider2D>();
            _trailRenderer = GetComponentInChildren<TrailRenderer>();
            
            _checkDelay = new(1f / visibilityChecksPerSecond);
            _cullDelay = new(cullDelay);
        }

        private void OnEnable()
        {
            _collider2d.enabled = true;
            _rigidbody2d.AddForce(transform.up * launchSpeed, ForceMode2D.Impulse);
            StartCoroutine(VisibilityChecker());
        }

        private void OnDisable()
        {
            _collider2d.enabled = false;
            _rigidbody2d.linearVelocity = Vector3.zero;
            _trailRenderer.Clear();
        }

        private IEnumerator VisibilityChecker()
        {
            while (gameObject.activeSelf)
            {
                var pos = _camera.WorldToScreenPoint(transform.position);

                if (!Screen.safeArea.Contains(pos))
                {
                    _collider2d.enabled = false;
                    yield return _cullDelay;
                    Debug.Log("Releasing object from projectile");
                    ObjectPoolManager.ReturnToPool(gameObject);
                }

                yield return _checkDelay; 
            }
        }
    }
}
