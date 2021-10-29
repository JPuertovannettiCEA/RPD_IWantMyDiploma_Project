using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugEnemyAI : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontalMove;
    
    [SerializeField]
    private float _runSpeed = 20f;  

    void Update()
    {
        horizontalMove = 1;
        controller.Move(horizontalMove * Time.deltaTime * _runSpeed, false,false,0f, null);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("EnemyCollider"))
        {
            horizontalMove = horizontalMove * -1;
        }
    }
}
