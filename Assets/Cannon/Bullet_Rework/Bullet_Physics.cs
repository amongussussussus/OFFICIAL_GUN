using System.Numerics;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet_Physics : MonoBehaviour
{
    Rigidbody2D bullet_rb;
    SpriteRenderer bullet_image;
    [SerializeField] GameObject damage_zone;
    private Cannon cannon;
    IDestroyable destroy;
    [SerializeField] ParticleSystem system;
       void Start()
    {
        bullet_rb = GetComponent<Rigidbody2D>();
        bullet_image = GetComponent<SpriteRenderer>();
        cannon = GetComponentInParent<Cannon>();
        bullet_rb.angularDamping = 0;
        bullet_rb.linearVelocity = cannon.ReturnAngle()*cannon.Power_Tuning();
        
    }

    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Vector2 position = bullet_rb.transform.position;
        if(collision.gameObject.GetComponent<IDestroyable>() != null)
        {
        damage_zone = Instantiate(damage_zone, position, bullet_rb.transform.rotation);
        Destroy(gameObject);
        }
        if(collision.gameObject.GetComponentInChildren<Armore>() != null)
        {
            float impact_angel = UnityEngine.Vector2.Dot(-bullet_rb.transform.up, collision.gameObject.transform.up);
            
            if (impact_angel > 0.6)
            {
                Destroy(gameObject);
                Debug.Log("Penetrated");
            }
            else
            {
                Debug.Log("Ricochet");
                Destroy(gameObject);
            }
        }
    }
}
