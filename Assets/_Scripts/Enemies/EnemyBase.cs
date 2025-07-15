using UnityEngine;

namespace CannonGame
{
    public class EnemyBase : MonoBehaviour
    {
        //base script which enemies will inherit from. Add to as needed. (eg if theres code a lot of enemies use you might as well put it in here and reference it)

        [SerializeField] GameObject player;
        [SerializeField] float speed;

        //call in enemy start function
        void Init()
        {
			player = GameObject.FindGameObjectWithTag("Player");
		}
    }
}
