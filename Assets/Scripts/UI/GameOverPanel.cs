using UnityEngine;
using UnityEngine.UI;

namespace Pinball.UI
{
    public class GameOverPanel : MonoBehaviour
    {
        public Button restartButton;

        private void Awake()
        {
            restartButton.onClick.AddListener(OnRestartClicked);
        }

        private void OnRestartClicked()
        {
            Pinball.Core.GameManager.Instance.RestartGame();
        }
    }
}