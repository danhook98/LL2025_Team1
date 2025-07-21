using CannonGame.Audio;
using CannonGame.EventSystem;
using UnityEngine;

namespace CannonGame
{
    public class SoundDebug : MonoBehaviour
    {
        [SerializeField] AudioDataSOEvent playerShootEvent;
        [SerializeField] AudioDataSO playerShootSound;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerShootEvent.Invoke(playerShootSound);
            }
        }
    }
}
