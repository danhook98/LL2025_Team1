using CannonGame.EventSystem;
using UnityEngine;

namespace CannonGame
{
    public class ScoreIncreaserModule : MonoBehaviour
    {
        [SerializeField] IntEvent scoreEvent;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Increase(int amount)
        {
            scoreEvent.Invoke(amount);
        }
    }
}
