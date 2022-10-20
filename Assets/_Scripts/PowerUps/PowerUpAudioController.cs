using UnityEngine;

namespace _Scripts.PowerUps
{
    public class PowerUpAudioController : MonoBehaviour
    {
        public void PlayAudio(PowerUpType type)
        {
            var components = GetComponents(typeof(AudioSource));
            AudioSource source;

            switch (type)
            {
                case PowerUpType.IncreasePaddleSize:
                    source = (AudioSource)components[0];
                    source.Play();
                    break;
                case PowerUpType.IncreasePaddleSpeed:
                    source = (AudioSource)components[1];
                    source.Play();
                    break;
                case PowerUpType.StickyBall:
                    source = (AudioSource)components[2];
                    source.Play();
                    break;
            }
        }
    }
}