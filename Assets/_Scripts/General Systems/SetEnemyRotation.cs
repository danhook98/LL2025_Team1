using UnityEngine;

namespace CannonGame
{
    public class SetEnemyRotation : MonoBehaviour
    {
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void OnEnable()
        {
            Vector2 direction = Vector2.zero - (Vector2) _transform.position;

            float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);
        }
    }
}
