using System;
using UnityEngine;

namespace Controller
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    [DisallowMultipleComponent]
    public class CreatureMover : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField]
        private float m_Speed = 3f;
        [SerializeField, Range(0f, 360f)]
        private float m_RotateSpeed = 90f;

        [Header("Animator")]
        [SerializeField]
        private string m_VerticalID = "Vert";

        private Transform m_Transform;
        private Rigidbody m_Rigidbody;
        private Animator m_Animator;

        private Vector2 m_Axis;
        private bool m_IsMoving;

        public Vector2 Axis => m_Axis;

        private void Awake()
        {
            m_Transform = transform;
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Animator = GetComponent<Animator>();
            
            // Freeze Y position untuk AR
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        private void FixedUpdate()
        {
            MoveCharacter();
            RotateCharacter();
            UpdateAnimation();
        }

        private void MoveCharacter()
        {
            if (m_IsMoving)
            {
                // Movement hanya di X dan Z axis
                Vector3 movement = new Vector3(m_Axis.x, 0, m_Axis.y);
                m_Rigidbody.velocity = movement * m_Speed;
            }
            else
            {
                // Stop movement
                m_Rigidbody.velocity = new Vector3(0, m_Rigidbody.velocity.y, 0);
            }
        }

        private void RotateCharacter()
        {
            if (m_IsMoving)
            {
                // Rotate character sesuai arah movement
                float targetAngle = Mathf.Atan2(m_Axis.x, m_Axis.y) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
                
                m_Transform.rotation = Quaternion.RotateTowards(
                    m_Transform.rotation, 
                    targetRotation, 
                    m_RotateSpeed * Time.fixedDeltaTime
                );
            }
        }

        private void UpdateAnimation()
        {
            if (m_Animator != null)
            {
                // Set animation parameter berdasarkan movement
                float animationSpeed = m_IsMoving ? m_Axis.magnitude : 0f;
                m_Animator.SetFloat(m_VerticalID, animationSpeed);
            }
        }

        public void SetInput(in Vector2 axis, in Vector3 target, in bool isRun, in bool isJump)
        {
            m_Axis = axis;

            if (m_Axis.sqrMagnitude < Mathf.Epsilon)
            {
                m_Axis = Vector2.zero;
                m_IsMoving = false;
            }
            else
            {
                m_Axis = Vector2.ClampMagnitude(m_Axis, 1f);
                m_IsMoving = true;
            }
        }
    }
}