using UnityEngine; 
using CannonGame.Audio; 

namespace CannonGame.EventSystem
{
    [CreateAssetMenu(fileName = "Audio Data Event",
                     menuName = Constants.MenuNameCustom + "Audio Data Event")]
    public class AudioDataSOEvent : GameEvent<AudioDataSO> { }
}