using UnityEngine;
using UnityEngine.Rendering;


    public class Movement : MonoBehaviour
    {
        public float Acceleration = 5f;
        protected float m_MovementSmoothing = 0.05f;

        protected Collider2D _collider;
        protected Rigidbody2D _rigidBody;
        protected WeaponHandler _weaponHandler;

        protected bool isMoving = false;

        protected Vector2 _InputDirection;
        protected Vector2 m_Velocity = Vector2.zero;
        protected Vector2 _targetVelocity = Vector2.zero;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected virtual void Start()
        {
            _collider = GetComponent<Collider2D>();
            _rigidBody = GetComponent<Rigidbody2D>();
            _weaponHandler = GetComponent<WeaponHandler>(); 
        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
            HandleMovement();
            HandleRotation();

        }

        protected virtual void HandleInput()
        {

        }
        protected virtual void HandleMovement()
        {
            if (_rigidBody == null || _collider == null)
                return;

                Vector2 targeVelocity = Vector2.zero;

            _targetVelocity = new Vector2(_InputDirection.x * Acceleration, _InputDirection.y * Acceleration);

            _rigidBody.linearVelocity = Vector2.SmoothDamp(_rigidBody.linearVelocity, _targetVelocity, ref m_Velocity, m_MovementSmoothing);

            isMoving = _targetVelocity.x !=0 || _targetVelocity.y !=0;

            _targetVelocity = _targetVelocity;
        }
        protected virtual void HandleRotation()
        {
            if (_InputDirection == Vector2.zero)
                return;

            transform.rotation = Quaternion.LookRotation(Vector3.forward, _targetVelocity);
            

            
        }

    }





