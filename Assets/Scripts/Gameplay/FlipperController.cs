using UnityEngine;

namespace Pinball.Gameplay
{
    public class FlipperController : MonoBehaviour
    {
        public KeyCode activationKey = KeyCode.Z;
        public float restAngle = 0f;
        public float flickAngle = 45f;
        public float strength = 1000f;
        private HingeJoint hinge;

        void Start()
        {
            hinge = GetComponent<HingeJoint>();
        }

        void Update()
        {
            JointSpring spring = hinge.spring;
            if (Input.GetKey(activationKey))
            {
                spring.targetPosition = flickAngle;
            }
            else
            {
                spring.targetPosition = restAngle;
            }
            hinge.spring = spring;
        }
    }
}