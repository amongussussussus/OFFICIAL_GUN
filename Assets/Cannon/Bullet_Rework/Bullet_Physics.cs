using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet_Physics : MonoBehaviour
{
    private float timer = 0.1f;
    private bool hasPushed = true;
    Rigidbody2D bullet_rb;
    GameObject bullet;
    [SerializeField] GameObject damage_zone;
    [SerializeField] private Cannon cannon;
       void Start()
    {
        bullet = GetComponent<GameObject>();
        bullet_rb = GetComponent<Rigidbody2D>();
        bullet_rb.angularDamping = 2000f;
        Debug.Log("Lifted");
    }

    void Update()
    {
        {
        if (timer >= 0 && hasPushed == true)
        {
            timer -= 1*Time.deltaTime;
            bullet_rb.AddForceAtPosition(bullet_rb.transform.up*cannon.Power_Tuning(), new Vector2(0,0));
        }
            else if (timer <= 0 && hasPushed == true)
            {
            Debug.Log("Stop pushing");
            hasPushed = false;
        }
    
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 position = bullet.transform.position;
        damage_zone = Instantiate(damage_zone, position, bullet.transform.rotation);
        Destroy(gameObject);
       
        
    }
}
