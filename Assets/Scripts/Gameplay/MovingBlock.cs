using UnityEngine;

namespace Pinball.Gameplay
{
    public class MovingBlock : ObstacleBase
    {
        public Vector3 pointA;
        public Vector3 pointB;
        public float speed = 2f;
        private bool movingToB = true;

        private void Update()
        {
            Vector3 target = movingToB ? pointB : pointA;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target) < 0.01f)
                movingToB = !movingToB;
        }
    }
}