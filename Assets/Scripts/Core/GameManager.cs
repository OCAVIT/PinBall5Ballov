using UnityEngine;
using Pinball.Gameplay;

namespace Pinball.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Gameplay")]
        public int totalBalls = 3;
        private int ballsLeft;
        private bool isGameOver = false;

        public event System.Action<int> OnBallsChanged;
        public event System.Action OnGameOver;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            ballsLeft = totalBalls;
            OnBallsChanged?.Invoke(ballsLeft);
        }

        public void BallLost()
        {
            ballsLeft--;
            OnBallsChanged?.Invoke(ballsLeft);
            if (ballsLeft <= 0)
            {
                isGameOver = true;
                OnGameOver?.Invoke();
            }
        }

        public bool CanLaunchBall() => !isGameOver && FindObjectsOfType<BallController>().Length == 0;

        public void RestartGame()
        {
            isGameOver = false;
            ballsLeft = totalBalls;
            OnBallsChanged?.Invoke(ballsLeft);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}