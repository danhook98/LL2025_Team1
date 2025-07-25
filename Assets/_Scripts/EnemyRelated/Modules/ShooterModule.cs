using UnityEngine;

namespace CannonGame
{
    public class ShooterModule : MonoBehaviour
    {
        private Animator _animator; 

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Shoot(GameObject bullet, Transform shootPoint)
        {
            //Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            ObjectPoolManager.SpawnObject(bullet, shootPoint.position, shootPoint.rotation);

            if (_animator)
            {
                _animator.SetTrigger("Shoot");
            }
        }
    }
}
