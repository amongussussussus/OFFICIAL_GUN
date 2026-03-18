using System.Data.Common;
using System.Threading;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MainEnemy : MonoBehaviour
{
    private Rigidbody2D enemy_rb;
    private float health = 100f;
    [SerializeField] private Damage_zone damage;
    private float move_time = 10f;
    private float idle_time = 5f;
    [SerializeField] TextMeshPro time_debug;
    [SerializeField] Animator animator;
    void Start()
    {
        enemy_rb = GetComponent<Rigidbody2D>();
        enemy_rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move_time >= 0 )
        {
            enemy_rb.linearVelocityX = -1;
            if (enemy_rb.linearVelocityX == 0)
            {
                enemy_rb.linearVelocityY = 1;
            }
            animator.SetBool("IsMoving", true);
            
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
    void FixedUpdate()
    {
        if (move_time <= 0 )
        {
            idle_time -= 1*Time.deltaTime;
            if(idle_time <= 0 )
            {
                move_time = 10f;
            }
        }
        else
            {
                 move_time -= 1*Time.deltaTime;
                 idle_time = 5f;
            }
        time_debug.text = "Move: " + move_time + "Idle: " + idle_time;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<Damage_zone>() != null)
        {
            Damage();
            Debug.Log("In Damage zone");
        }

    }
    void Damage()
    {
        health -= 20;
        Debug.Log("It hurt, it hurt" + health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
