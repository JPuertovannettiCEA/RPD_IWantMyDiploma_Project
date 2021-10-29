using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontalMove;
    private bool _isBuild = false;

    private float verticalMove;
    private bool _isLadder = false;
    private bool _isClimbing = false;
    private bool _canBuild = false;
    private bool _onPlatform = false;

    [SerializeField]
    private Transform _buildCheck;
    
    [SerializeField]
    private float _runSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
        if(Input.GetKeyDown(KeyCode.Space) && _canBuild)
        {
            //Debug.Log($"SPACE");
            _isBuild = true;
        }
        
        verticalMove = Input.GetAxis("Vertical") * _runSpeed;
        if(_isLadder && Mathf.Abs(verticalMove) > 0)
        {
            _isClimbing = true;
            _onPlatform = false;
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, _isBuild, _isClimbing, verticalMove * Time.fixedDeltaTime, _buildCheck);
        _isBuild = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ladder"))
        {
            _isLadder = true;
        }

        if(other.CompareTag("Build"))
        {
            _canBuild = true;
            _buildCheck = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Ladder"))
        {
            _isLadder = false;
            _isClimbing = false;
        }

        if(other.CompareTag("Build"))
        {
            _canBuild = false;
            _buildCheck = null;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Platform") && !_onPlatform)
        {
            Debug.Log($"ESTAS COLLISIONANDO CON UN A PLATAFORMA");
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
            _onPlatform = true;
        }
    }
}
