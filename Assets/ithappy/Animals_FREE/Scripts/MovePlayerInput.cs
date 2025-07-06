using UnityEngine;

namespace Controller
{
    [RequireComponent(typeof(CreatureMover))]
    public class MovePlayerInput : MonoBehaviour
    {
        [Header("Joystick Control")]
        [SerializeField]
        private FixedJoystick fixedJoystick;

        private CreatureMover m_Mover;
        private Vector2 m_Axis;
        private Vector3 m_Target;

        private void Awake()
        {
            m_Mover = GetComponent<CreatureMover>();
        }

        private void OnEnable()
        {
            // Cari FixedJoystick di scene jika belum di-assign
            if (fixedJoystick == null)
            {
                fixedJoystick = FindObjectOfType<FixedJoystick>();
            }
        }

        private void Update()
        {
            GatherInput();
            SetInput();
        }

        public void GatherInput()
        {
            if (fixedJoystick != null)
            {
                // Ambil input dari joystick (x dan z movement)
                m_Axis = new Vector2(fixedJoystick.Horizontal, fixedJoystick.Vertical);
                
                // Target tetap di posisi karakter untuk AR (tidak perlu camera target)
                m_Target = transform.position + transform.forward;
            }
            else
            {
                m_Axis = Vector2.zero;
                m_Target = transform.position + transform.forward;
            }
        }

        public void BindMover(CreatureMover mover)
        {
            m_Mover = mover;
        }

        public void SetInput()
        {
            if (m_Mover != null)
            {
                // Tidak perlu run dan jump untuk AR application
                m_Mover.SetInput(in m_Axis, in m_Target, false, false);
            }
        }
    }
}