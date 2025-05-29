using UnityEngine;

namespace Pinball.Core
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }
        private int score = 0;
        public event System.Action<int> OnScoreChanged;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void AddScore(int amount)
        {
            score += amount;
            OnScoreChanged?.Invoke(score);
        }

        public int GetScore() => score;
    }
}