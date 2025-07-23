using CannonGame.EventSystem;
using UnityEngine;
using CannonGame.EventSystem;
using CannonGame.Audio; 

namespace CannonGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5f;

        [Header("Shooting")]
        [SerializeField] private Transform firePoint;
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private float fireDelay = 0.12f;

        [Header("Audio")]
        [SerializeField] private AudioDataSOEvent playSFXEvent;
        [SerializeField] private AudioDataSO shootSound; 

        private Camera _camera; 
        private Transform _transform;

        private Vector2 _mousePosition;

        private float _nextFireTime;

        [SerializeField] VoidEvent PlayerShot;

        private void Awake() 
        {
            _camera = Camera.main;
            _transform = transform;

            _nextFireTime = Time.time + fireDelay;
        }

        private void Update()
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            RotateTurret();

            if (Input.GetMouseButton(0) && _nextFireTime < Time.time)
            {
                Projectile projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

                _nextFireTime = Time.time + fireDelay;
                PlayerShot.Invoke();

                playSFXEvent.Invoke(shootSound);    
            }
        }

        private void RotateTurret()
        {
            Vector2 direction = (_mousePosition - (Vector2) _transform.position).normalized;

            // No point running the rotation calculations if the mouse cursor is directly on top of the turret.
            if (direction == Vector2.zero) return;

            // Get the angle fron the given direction, and convert it from gross radians to superior degrees.
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Convert the target angle into a Quaternion for use in the lerp method.
            Quaternion targetAngle = Quaternion.Euler(0f, 0f, angle);

            // Linearly interpolate to the target angle. I discovered the below formula for the lerp's 't' variable
            // when researching for frame-rate independent lerping on Rory Driscoll's 'Codeitnow' blog. 
            Quaternion smoothedRotation = Quaternion.Lerp( transform.rotation, targetAngle, 
                1f - Mathf.Exp( -rotationSpeed * Time.deltaTime ) );

            _transform.rotation = smoothedRotation;
        }
    }
}
