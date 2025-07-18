using UnityEngine;

namespace CannonGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5f;

        private Camera _camera; 
        private Transform _transform;

        private Vector2 _mousePosition;

        private void Awake() 
        {
            _camera = Camera.main;
            _transform = transform;
        }

        private void Update()
        {
            _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

            RotateTurret();
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
