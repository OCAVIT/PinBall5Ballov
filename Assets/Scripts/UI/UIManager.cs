using UnityEngine;
using UnityEngine.UI;
using Pinball.Core;

namespace Pinball.UI
{
    public class UIManager : MonoBehaviour
    {
        public Text scoreText;
        public Text ballsText;
        public GameObject gameOverPanel;

        void Start()
        {
            ScoreManager.Instance.OnScoreChanged += UpdateScore;
            GameManager.Instance.OnBallsChanged += UpdateBalls;
            GameManager.Instance.OnGameOver += ShowGameOver;
            UpdateScore(0);
            UpdateBalls(GameManager.Instance.totalBalls);
            gameOverPanel.SetActive(false);
        }

        void UpdateScore(int score) => scoreText.text = $"Score: {score}";
        void UpdateBalls(int balls) => ballsText.text = $"Balls: {balls}";
        void ShowGameOver() => gameOverPanel.SetActive(true);

        public void OnRestartButton()
        {
            GameManager.Instance.RestartGame();
        }
    }
}