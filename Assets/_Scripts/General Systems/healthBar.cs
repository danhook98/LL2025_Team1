using UnityEngine;
using UnityEngine.UI;

namespace CannonGame
{
    public class healthBar : MonoBehaviour
    {
        [SerializeField] Slider slider;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            slider = GetComponent<Slider>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void decreaseHealthValue(float amount)
        {
            slider.value -= amount;
        }
    }
}
