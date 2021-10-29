using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundlayer;

    private void Start()
    {
        mustPatrol = true;
    }

    private void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
        }
    }

    private void Patrol()
    {
        if(mustTurn)
        {
            Flip();
        }
        _rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, _rb.velocity.y);
    }

    private void Flip()
    {
        mustPatrol = false;
        transform.localScale = new  Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Flip();
        }
    }
}
