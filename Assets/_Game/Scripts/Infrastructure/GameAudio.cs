using UnityEngine;

namespace _Game.Scripts.Infrastructure
{
    public class GameAudio
    {
        private AudioSource _audioSource;

        public float Volume { get; private set; } = 0.3f;
        public bool IsMuted { get; private set; }

        public void Assign(AudioSource audioSource)
        {
            _audioSource = audioSource;
            _audioSource.mute = IsMuted;
            _audioSource.volume = Volume;
        }

        public void ChangeVolume(float to)
        {
            Volume = to;
            _audioSource.volume = to;
        }

        public void PlaySound()
        {
            _audioSource.Play();
        }

        public void ToggleSound()
        {
            _audioSource.mute = !_audioSource.mute;
            IsMuted = _audioSource.mute;
        }
    }
}
