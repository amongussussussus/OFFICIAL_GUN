using System.Drawing;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.InputSystem;

public class Movingandcrouch : MonoBehaviour
{

    Rigidbody2D player_rb;
    BoxCollider2D player_col;
    [SerializeField] private Animator animator;
    private bool isGround;
    private bool isCrouch;

    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        player_col = GetComponent<BoxCollider2D>();
        player_rb.freezeRotation = true; 
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftRight();
        Jump();
        Crouch();
    }
    private void FixedUpdate()
    {
        animator.SetBool("IsGround", IsGrounded());
        if (IsGrounded()==true)
        {
            player_rb.linearDamping = 100;
        }
        else
        {
            player_rb.linearDamping = 0;
        }
    }
    private void LeftRight()
    {
        animator.SetBool("IsMoving", false);
        float moveSpeed = 5f;
        if (animator.GetBool("IsCrouch") == true)
        {
            moveSpeed = moveSpeed*0.5f;
        }
        if(Keyboard.current.aKey.IsPressed())
        {
            player_rb.linearVelocityX = -moveSpeed;
            animator.SetBool("IsMoving", true);
             player_rb.transform.localScale = new Vector3(-1,1,1);
        }
        
        if(Keyboard.current.dKey.IsPressed())
        {
            player_rb.linearVelocityX = moveSpeed;
            animator.SetBool("IsMoving", true);
            player_rb.transform.localScale = new Vector3(1,1,1);
        }
    }
    private void Jump()
    {
        float jumpForce = 200f;
        if(Keyboard.current.spaceKey.IsPressed() && IsGrounded() == true)
        {
            player_rb.AddForce(player_rb.transform.up*jumpForce);
        }

    }
    private void Crouch()
    {
        animator.SetBool("IsCrouch", false);
        player_col.size = new Vector2(0.5f,1.2f);
        if(Keyboard.current.sKey.IsPressed())
        {
            animator.SetBool("IsCrouch", true);
            player_col.size = new Vector2(0.5f,0.6f);
        }
    }
   private bool IsGrounded()
{
    return player_rb.linearVelocity.y == 0;
}
}
