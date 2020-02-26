using UnityEngine;

namespace KartGame.KartSystems
{
    /// <summary>
    /// A basic gamepad implementation of the IInput interface for all the input information a kart needs.
    /// </summary>
    public class GamepadInput : MonoBehaviour, IInput
    {
        public float Acceleration
        {
            get { return m_Acceleration; }
        }
        public float Steering
        {
            get { return m_Steering; }
        }
        public bool BoostPressed
        {
            get { return m_BoostPressed; }
        }
        public bool FirePressed
        {
            get { return m_FirePressed; }
        }
        public bool HopPressed
        {
            get { return m_HopPressed; }
        }
        public bool HopHeld
        {
            get { return m_HopHeld; }
        }

        float m_Acceleration;
        float m_Steering;
        bool m_HopPressed;
        bool m_HopHeld;
        bool m_BoostPressed;
        bool m_FirePressed;

        bool m_FixedUpdateHappened;

        Vector2 m_Position;

        void Update ()
        {
            if (Input.GetTouch(0).tapCount == 1)
                m_Acceleration = -1f;
            else if (Input.GetTouch(0).tapCount == 2)
                m_Acceleration = 1f;
            else
                m_Acceleration = 0f;

            Touch touch = Input.GetTouch(0);
            TouchPhase phase = touch.phase;

            if (phase == TouchPhase.Began)
                m_Position = touch.position;
            else if (phase == TouchPhase.Moved) 
            {
                Vector2 pos = (touch.position - m_Position);
                pos.Normalize();
                m_Steering =  pos.x; //Input.GetAxis ("Horizontal");
            }

            m_HopHeld = Input.GetButton ("Hop");

            if (m_FixedUpdateHappened)
            {
                m_FixedUpdateHappened = false;

                m_HopPressed = false;
                m_BoostPressed = false;
                m_FirePressed = false;
            }

            m_HopPressed |= Input.GetButtonDown ("Hop");
            m_BoostPressed |= Input.GetButtonDown ("Boost");
            m_FirePressed |= Input.GetButtonDown ("Fire");
        }

        void FixedUpdate ()
        {
            m_FixedUpdateHappened = true;
        }
    }
}