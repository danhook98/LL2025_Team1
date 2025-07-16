using UnityEngine;

namespace CannonGame.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSourceSFX;
        [SerializeField] private AudioSource audioSourceMusic;

        private void Awake()
        {
            // Tried creating a method to verify the audio sources but Unity threw a hissy fit, so manual it is!
            if (!audioSourceSFX)
            {
                Debug.LogWarning("<color=red>AudioManager</color>: SFX audio source not assigned or is invalid, " +
                    "creating a temporary one. Expect weird behaviour.");

                audioSourceSFX = gameObject.AddComponent<AudioSource>();
            }

            if (!audioSourceMusic)
            {
                Debug.LogWarning("<color=red>AudioManager</color>: music audio source not assigned or is invalid, " +
                    "creating a temporary one. Expect weird behaviour.");

                audioSourceMusic = gameObject.AddComponent<AudioSource>();
            }
        }
    }
}
