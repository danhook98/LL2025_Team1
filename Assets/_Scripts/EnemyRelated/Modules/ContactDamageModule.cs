using UnityEngine;

namespace CannonGame
{
	public class ContactDamageModule : MonoBehaviour
	{
		[SerializeField] float damage;
		[SerializeField] string exclusionTag;

		public void OnTriggerEnter2D(Collider2D collision)
		{
			if (!collision.CompareTag(exclusionTag) && exclusionTag != "")
			{
				return;
			}
			if (collision.gameObject.GetComponent<HealthSystem>() == null)
			{
				return;
			}
			collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
