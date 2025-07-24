using UnityEngine;

namespace CannonGame
{
	public class ContactDamageModule : MonoBehaviour
	{
		[SerializeField] private float damage;
		[SerializeField] private string exclusionTag;
        [SerializeField] private bool isPoolable = false; 

		public void OnTriggerEnter2D(Collider2D collision)
		{
            if (!collision.CompareTag(exclusionTag) && exclusionTag != "") return;

            if (collision.gameObject.TryGetComponent<HealthSystem>(out var healthSystem))
            {
                healthSystem.TakeDamage(damage);
            }

            if (isPoolable)
            {
                ObjectPoolManager.ReturnToPool(gameObject);
                return; 
            }

            Destroy(gameObject);
        }
	}
}
