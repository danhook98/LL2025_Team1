using UnityEngine;
using Random = UnityEngine.Random; 

namespace CannonGame.Audio
{
    [CreateAssetMenu(fileName = "Audio Data",
                     menuName = "CannonGame/Audio/Audio Data")]
    public class AudioDataSO : ScriptableObject
    {
        // Exposed data. 
        public AudioClip[] clips;
        [Space]
        [Range(0f, 1f)] public float volume = 1f;

        [Header("Pitch")]
        public bool useRandomPitch = false;
        [Range(0.1f, 2f)] public float minimumPitch = 1f;
        [Range(0.1f, 2f)] public float maximumPitch = 1f;

        // Instance dependent properties and methods. 
        public bool IsValid { get; private set; } = true; 

        // Verify that all of the clips in the clips array are valid. 
        private void OnEnable()
        {
            IsValid = VerifyClips(this);

            if (!IsValid)
                Debug.LogWarning($"<color=red>AudioDataSO</color> ('{name}'): clips array contains an empty index.");
        }

        /// <summary>
        /// Gets an audio clip from the available clips. 
        /// </summary>
        public AudioClip GetClip() => GetRandomClip(this);

        /// <summary>
        /// Verifies that all indexes of an AudioDataSO's clips has a valid AudioClip set.
        /// </summary>
        /// <param name="audioData">AudioDataSO object.</param>
        /// <returns>Validity of clips.</returns>
        private static bool VerifyClips(AudioDataSO audioData)
        {
            foreach (var clip in audioData.clips)
            {
                if (clip) continue;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets a random audio clip from the given AudioDataSO object. 
        /// </summary>
        /// <param name="audioData">AudioDataSO object.</param>
        /// <returns>Random audio clip.</returns>
        private static AudioClip GetRandomClip(AudioDataSO audioData)
        {
            return audioData.clips[Random.Range(0, audioData.clips.Length)];
        }
    }
}
