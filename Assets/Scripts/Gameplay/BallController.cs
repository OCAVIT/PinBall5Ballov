using UnityEngine;
using Pinball.Core;

namespace Pinball.Gameplay
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour
    {
        private Rigidbody rb;
        private bool isOutOfPlay = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BallOutZone") && !isOutOfPlay)
            {
                isOutOfPlay = true;
                GameManager.Instance.BallLost();
                Destroy(gameObject);
            }
        }
    }
}