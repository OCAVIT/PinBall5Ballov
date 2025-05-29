using Pinball.Core;
using UnityEngine;

namespace Pinball.Gameplay
{
    public class PlungerController : MonoBehaviour
    {
        public Transform ballSpawnPoint;
        public GameObject ballPrefab;
        public float maxPull = 1f;
        public float forceMultiplier = 1f;

        private float pullAmount = 0f;
        private bool isPulling = false;
        private GameObject currentBall;

        void Update()
        {
            if (GameManager.Instance.CanLaunchBall())
            {
                if (currentBall == null)
                {
                    currentBall = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
                    var rb = currentBall.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                }

                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
                {
                    isPulling = true;
                    pullAmount = Mathf.Min(pullAmount + Time.deltaTime * 2, maxPull);
                }
                else if (isPulling && currentBall != null)
                {
                    var rb = currentBall.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.AddForce(transform.forward * pullAmount * forceMultiplier, ForceMode.Impulse);

                    if (currentBall.GetComponent<BallController>() == null)
                        currentBall.AddComponent<BallController>();

                    pullAmount = 0f;
                    isPulling = false;
                    currentBall = null;
                }
            }
        }
    }
}