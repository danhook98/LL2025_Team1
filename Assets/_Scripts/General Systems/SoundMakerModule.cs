using CannonGame.Audio;
using CannonGame.EventSystem;
using UnityEngine;

namespace CannonGame
{
    public class SoundMakerModule : MonoBehaviour
    {
        [SerializeField] AudioDataSOEvent audioEvent;
        public void MakeSound(AudioDataSO sound)
        {
            audioEvent.Invoke(sound);
        }
    }
}
