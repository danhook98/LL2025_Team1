using CannonGame.EventSystem;
using UnityEngine;

namespace CannonGame.Audio
{
    [CreateAssetMenu(fileName = "Audio Data",
                     menuName = "CannonGame/Audio/Audio Data")]
    public class AudioDataSO : ScriptableObject
    {
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f;
    }
}
