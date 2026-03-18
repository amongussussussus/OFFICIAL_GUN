using System.Data.Common;
using System.Diagnostics;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MainEnemy : MonoBehaviour
{
    private Rigidbody2D enemy_rb;
    private float health = 100f;
    [SerializeField] private GameObject loot_1, loot_2, loot_3;
    private float move_time = 10f;
    private float idle_time = 5f;
    [SerializeField] Animator animator;
    Gamemaster gamemaster;
    
    void Start()
    {
        enemy_rb = GetComponent<Rigidbody2D>();
        enemy_rb.freezeRotation = true;
        gamemaster = FindAnyObjectByType<Gamemaster>();
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
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
    }
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<Damage_zone>() != null)
        {
            Damage();
        }

    }
    void Damage()
    {
        health -= 20;
        if (health <= 0)
        {
            int loot_ammount = Random.Range(1,5);
            for(int i=0;i<loot_ammount;i++)
            {
                int loot_index = Random.Range(1,4);
                switch (loot_index)
                {
                    case 1:
                     GameObject loot1 = Instantiate(loot_1, enemy_rb.transform.position, enemy_rb.transform.rotation);
                     break;
                    case 2:
                    GameObject loot2 = Instantiate(loot_2, enemy_rb.transform.position, enemy_rb.transform.rotation);
                    break;
                    case 3:
                    GameObject loot3 = Instantiate(loot_3, enemy_rb.transform.position, enemy_rb.transform.rotation);
                    break;

                }   
            } 
            gamemaster.PlayerScore(20);
            Destroy(gameObject);
        }
    }
}
