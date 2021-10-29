using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontalMove;
    private bool build = false;
    
    [SerializeField]
    private float _runSpeed = 40f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log($"SPACE");
            build = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, build, false);
        build = false;
    }
}
