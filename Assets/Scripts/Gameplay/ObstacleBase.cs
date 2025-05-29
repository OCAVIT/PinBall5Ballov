using UnityEngine;

namespace Pinball.Gameplay
{
    public abstract class ObstacleBase : MonoBehaviour
    {
        [Header("Score")]
        public int baseScore = 50;

        protected virtual void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                OnBallHit(collision);
            }
        }

        protected virtual void OnBallHit(Collision collision)
        {
            Core.ScoreManager.Instance.AddScore(baseScore);
        }
    }
}