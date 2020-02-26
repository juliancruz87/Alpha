using UnityEngine;

namespace KartGame.KartSystems
{
    public class MobileInput : MonoBehaviour, IInput
    {
        private readonly string m_HorizontalAxis = "Horizontal";
        private readonly string m_JumpAxis = "Jump";
        private readonly string m_FireAxis3 = "Fire3";
        private readonly string m_FireAxis2 = "Fire2";
        private readonly string m_FireAxis1 = "Fire1";

        public float Acceleration
        {
            get; private set; 
        }
        public float Steering
        {
            get; private set;
        }
        public bool BoostPressed
        {
            get; private set;
        }
        public bool FirePressed
        {
            get; private set;
        }
        public bool HopPressed
        {
            get; private set;
        }
        public bool HopHeld
        {
            get; private set;
        }

        bool m_FixedUpdateHappened;

        void Update()
        {
            if (Input.GetButton(m_FireAxis3))
                Acceleration = 1f;
            else if (Input.GetButton(m_FireAxis1))
                Acceleration = -1f;
            else
                Acceleration = 0f;

            Steering = Input.GetAxis(m_HorizontalAxis);

            HopHeld = Input.GetButtonDown(m_JumpAxis);

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                HopPressed = false;
                BoostPressed = false;
                FirePressed = false;
            }

            HopPressed |= Input.GetButton(m_JumpAxis);
            BoostPressed |= Input.GetButton(m_FireAxis2);
        }

        void FixedUpdate()
        {
            m_FixedUpdateHappened = true;
        }
    }
}