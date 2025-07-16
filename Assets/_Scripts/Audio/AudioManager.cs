using UnityEngine;
using UnityEngine.Audio;

namespace CannonGame.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [Header("Audio Sources")]
        [SerializeField] private AudioSource audioSourceSFX;
        [SerializeField] private AudioSource audioSourceMusic;
        [Space]
        [SerializeField] private AudioMixer audioMixer;

        private readonly string[] _mixerParameters = { "MasterVolume", "SFXVolume", "MusicVolume" };

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

            if (!audioMixer)
            {
                Debug.LogWarning("<color=red>AudioManager</color>: audio mixer not set, all volume levels will be " +
                                 "at their default values.");
            }
        }

        private void Start() => LoadVolume();

        /// <summary>
        /// Plays a one shot sound from the given audio data.
        /// </summary>
        /// <param name="audioData">AudioDataSO data asset.</param>
        public void PlaySFX(AudioDataSO audioData)
        {
            if (!audioData.clip)
            {
                Debug.LogWarning($"<color=red>Audio Manager</color>: Attempted to play audio one shot for " +
                                 $"{audioData.name}, but clip data is null.");
                return;
            }

            audioSourceSFX.PlayOneShot(audioSourceSFX.clip, audioData.volume);
        }

        /// <summary>
        /// Plays a continuous sound from the given audio data.
        /// </summary>
        /// <param name="audioData">AudioDataSO data asset.</param>
        public void PlayMusic(AudioDataSO audioData)
        {
            if (!audioData.clip)
            {
                Debug.LogWarning($"<color=red>Audio Manager</color>: Attempted to play audio music for " +
                                 $"{audioData.name}, but clip data is null.");
                return;
            }

            audioSourceMusic.clip = audioData.clip;
            audioSourceMusic.volume = audioData.volume;
            audioSourceMusic.Play();
        }

        /// <summary>
        /// Stops audio playing from the music audio source.
        /// </summary>
        public void StopMusic() => audioSourceMusic.Stop();

        /// <summary>
        /// Sets the master volume. 
        /// </summary>
        /// <param name="volume">Volume value, between 0 and 1.</param>
        public void SetMasterVolume(float volume) => SetVolume("MasterVolume", volume);

        /// <summary>
        /// Sets the sound effects volume. 
        /// </summary>
        /// <param name="volume">Volume value, between 0 and 1.</param>
        public void SetSFXVolume(float volume) => SetVolume("SFXVolume", volume);

        /// <summary>
        /// Sets the music volume. 
        /// </summary>
        /// <param name="volume">Volume value, between 0 and 1.</param>
        public void SetMusicVolume(float volume) => SetVolume("MusicVolume", volume);

        /// <summary>
        /// Sets the volume of the given mixer parameter to the given volume. Values outside of 0-1 are ignored.
        /// </summary>
        /// <param name="mixerParameter">Mixer group parameter.</param>
        /// <param name="volume">Volume level.</param>
        private void SetVolume(string mixerParameter, float volume)
        {
            if (volume is < 0 or > 1)
            {
                Debug.LogWarning($"<color=red>Audio Manager</color>: Attempting to set volume for {mixerParameter}, " +
                                 $"but the volume value ({volume}) was outside the range [0, 1].");
                return;
            }

            // Prevent multiply by zero values.
            if (volume is 0) volume = 0.0001f;

            // Convert the 0-1 float volume value into a base 10 logarithmic curve. This ensures that the volume change
            // in the mixer sounds correct to our ears, as anything below -20 dB is essentially silent to us. 
            float mixerVolume = Mathf.Log10(volume) * 20;

            // Set the volume of the mixer group, and update the volume in PlayerPrefs for loading. 
            audioMixer.SetFloat(mixerParameter, mixerVolume);
            PlayerPrefs.SetFloat(mixerParameter, mixerVolume);
        }

        /// <summary>
        /// Loads all of the saved mixer group volume levels. Non-existent values in PlayerPrefs are set to 0.
        /// </summary>
        private void LoadVolume()
        {
            foreach (string parameter in _mixerParameters)
            {
                float mixerVolume = PlayerPrefs.GetFloat(parameter, 0f);
                audioMixer.SetFloat(parameter, mixerVolume);
            }
        }
    }
}
