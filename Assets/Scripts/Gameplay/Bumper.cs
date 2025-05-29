using UnityEngine;

namespace Pinball.Gameplay
{
    public class Bumper : ObstacleBase
    {
        public float bumpForce = 10f;

        protected override void OnBallHit(Collision collision)
        {
            base.OnBallHit(collision);
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                Vector3 forceDir = (collision.transform.position - transform.position).normalized;
                ballRb.AddForce(forceDir * bumpForce, ForceMode.Impulse);
            }
        }
    }
}