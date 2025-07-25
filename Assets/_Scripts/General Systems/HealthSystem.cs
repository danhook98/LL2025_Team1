using UnityEngine;
using UnityEngine.Events;

namespace CannonGame
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] float maxHealth;
        float currentHealth;
        [SerializeField] private bool isPoolable = false;
        [SerializeField] UnityEvent<float> OnDamaged;
        [SerializeField] UnityEvent<float> OnHealed;
        [SerializeField] UnityEvent OnDeath;

        private void OnEnable()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            OnDamaged.Invoke(damage);
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public void Heal(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            OnHealed.Invoke(amount);
        }

        void Die()
        {
            OnDeath.Invoke();

            if (isPoolable)
            {
                ObjectPoolManager.ReturnToPool(gameObject);
                return;
            }

            Destroy(gameObject);
        }
    }
}
