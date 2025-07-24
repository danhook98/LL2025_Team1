using UnityEngine;

namespace CannonGame
{
    public class ShooterModule : MonoBehaviour
    {
        [SerializeField] Animator anim;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Shoot(GameObject bullet, Transform shootPoint)
        {
            Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            if (anim)
            {
                anim.SetTrigger("Shoot");
            }
        }
    }
}
