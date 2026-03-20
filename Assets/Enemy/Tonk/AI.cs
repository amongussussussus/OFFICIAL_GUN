using Unity.VisualScripting;
using UnityEngine;

public class AI : MonoBehaviour
{
    Rigidbody2D Tank;
    public int Speed;
    private int health = 100;
    private float dismatle_time;
    [SerializeField] GameObject loot;
    void Start()
    {
        Tank = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Tank.linearVelocityX = Speed; 
        if (health<=0)
        {
            Speed = 0;
        }
    }
    public void Damage(int damage)
    {
        health -= 20;
        Debug.Log("Health left: " + health);
    }
    void OnMouseDown(Collider2D collider)
    {
        if(health<=0)
        {
        dismatle_time -= 1*Time.deltaTime;
        Debug.Log("Dismatling");
        if(dismatle_time<=0)
        {
            int ammo_nums = Random.Range(1,5);
            for(int i = 0; i< ammo_nums;i++)
            {
                GameObject looted = Instantiate(loot, Tank.transform.position,Tank.transform.rotation);
            }
            Destroy(gameObject);
        }
        }
    }
    void OnMouseDrag()
    {
            if(health<=0)
        {
        dismatle_time -= 1*Time.deltaTime;
        Debug.Log("Dismatling");
        if(dismatle_time<=0)
        {
            int ammo_nums = Random.Range(1,5);
            for(int i = 0; i< ammo_nums;i++)
            {
                GameObject looted = Instantiate(loot, Tank.transform.position,Tank.transform.rotation);
            }
            Destroy(gameObject);
        }
        }
    }
}
