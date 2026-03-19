using System.Drawing;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
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
    InputAction move_control;
    InputAction jump_control;
    
    [SerializeField]
    private float jump_force = 200f;
    [SerializeField]
    private float move_speed = 5f;
    private Vector2 move_direction = Vector2.zero;

    bool IsManned = false;
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        player_col = GetComponent<BoxCollider2D>();
        player_rb.freezeRotation = true;
        move_control = InputSystem.actions.FindAction("Move");//get project setting input control
        jump_control = InputSystem.actions.FindAction("Jump");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsManned == false)
        {
            move_direction = move_control.ReadValue<Vector2>();
        }
        LeftRight(move_direction);
        Jump();
        Crouch(move_direction);
        ExitVehicle();
    }
    private void FixedUpdate()
    {
        if(IsGrounded() == true)
        {
            animator.SetBool("IsGround", true);
        }
    }
    private void LeftRight(Vector2 move_direction)
    {
        animator.SetBool("IsMoving", false);
        float moveSpeed = move_speed;
        if (animator.GetBool("IsCrouch") == true)
        {
            moveSpeed = moveSpeed*0.5f;
        }
        if(move_direction.x < 0)
        {
            player_rb.linearVelocityX = -moveSpeed;
            animator.SetBool("IsMoving", true);
             player_rb.transform.localScale = new Vector3(-1,1,1);
        }
        
        if(move_direction.x > 0)
        {
            player_rb.linearVelocityX = moveSpeed;
            animator.SetBool("IsMoving", true);
            player_rb.transform.localScale = new Vector3(1,1,1);
        }
    }
    private void Jump()
    {
        float jumpForce = jump_force;
        
        if(jump_control.IsPressed() == true && IsGrounded() == true)
        {
            player_rb.AddForce(player_rb.transform.up*jumpForce);
            Debug.Log(player_rb.transform.up*jumpForce);
        }

    }
    private void Crouch(Vector2 move_direction)
    {
        animator.SetBool("IsCrouch", false);
        player_col.size = new Vector2(0.5f,1.2f);
        if(move_direction.y < 0)
        {
            animator.SetBool("IsCrouch", true);
            player_col.size = new Vector2(0.5f,0.6f);
        }
    }
   private bool IsGrounded()
{
    return player_rb.linearVelocity.y == 0;
}
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("In zone");
        if(collision.gameObject.GetComponent<Cannon>() != null && Keyboard.current.eKey.wasPressedThisFrame && IsManned == false)
        {
            gameObject.transform.SetParent(collision.gameObject.transform);
            gameObject.transform.localPosition = new Vector2(0,0);
            player_rb.transform.localScale = new Vector3(1,1,1);
            player_rb.constraints = RigidbodyConstraints2D.FreezePosition;
            IsManned = true;
            move_direction = Vector2.zero;
            Debug.Log("Manned");
    
        }
    }
    private void ExitVehicle()
    {
        if(IsManned == true && Keyboard.current.shiftKey.wasPressedThisFrame)
        {
            gameObject.transform.SetParent(null);
            player_rb.constraints = RigidbodyConstraints2D.None;
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            player_rb.freezeRotation = true;
            IsManned = false;
        }
    }
    public bool Get_Manned()
    {
        return IsManned;
    }
}