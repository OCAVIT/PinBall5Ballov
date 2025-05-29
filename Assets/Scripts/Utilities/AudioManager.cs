using UnityEngine;

namespace Pinball.Utilities
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        public AudioSource sfxSource;
        public AudioClip bumperClip;
        public AudioClip flipperClip;
        public AudioClip bonusClip;
        public AudioClip plungerClip;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void PlayBumper() => sfxSource.PlayOneShot(bumperClip);
        public void PlayFlipper() => sfxSource.PlayOneShot(flipperClip);
        public void PlayBonus() => sfxSource.PlayOneShot(bonusClip);
        public void PlayPlunger() => sfxSource.PlayOneShot(plungerClip);
    }
}