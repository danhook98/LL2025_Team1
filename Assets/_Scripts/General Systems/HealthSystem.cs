using UnityEngine;

namespace CannonGame
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] float maxHealth;
        float currentHealth;
		private void Start()
		{
            currentHealth = maxHealth;
		}


		public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if(currentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}
