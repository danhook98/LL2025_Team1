using UnityEngine;

namespace CannonGame
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        private float _moveSpeed;
        private Vector2 _direction; 

        private Rigidbody2D _rigidbody2d;

        private void Awake()
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();
        }
    }
}
