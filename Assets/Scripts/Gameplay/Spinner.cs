using UnityEngine;

namespace Pinball.Gameplay
{
    public class Spinner : ObstacleBase
    {
        public float rotationSpeed = 180f;

        private void Update()
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}