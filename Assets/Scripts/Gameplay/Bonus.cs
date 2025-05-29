using UnityEngine;
using UnityEngine.SceneManagement;
using Pinball.Core;

namespace Pinball.Gameplay
{
    public class Bonus : MonoBehaviour
    {
        public int scoreValue = 100;
        public event System.Action OnCollected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                ScoreManager.Instance.AddScore(scoreValue);
                OnCollected?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}