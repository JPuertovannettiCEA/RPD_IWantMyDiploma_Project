using UnityEngine.Events;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [Range(0, 0.3f)] [SerializeField]
    private float m_MovementSmoothing = .05f;
    
    [SerializeField]
    private LayerMask _WhatIsGround;

    [SerializeField]
    private Transform _groundCheck;

    const float _groundedRadius = .2f;
    private bool _grounded;
    private Rigidbody2D _rigidbody;
    private bool _facingRight;
    private Vector3 _velocity = Vector3.zero;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> {}

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        if(OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    private void FixedUpdate()
    {
        bool wasGrounded = _grounded;
        _grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, _WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                _grounded = true;
                if(!wasGrounded)
                {
                    OnLandEvent.Invoke();
                }
            }
        }
    }

    public void Move(float move)
    {
        if(_grounded)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, _rigidbody.velocity.y);

            _rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _velocity, m_MovementSmoothing);

            if(move > 0 && !_facingRight)
            {
                Flip();
            }
            else if(move < 0 && _facingRight)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
