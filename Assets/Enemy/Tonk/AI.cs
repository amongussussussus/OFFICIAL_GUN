using UnityEngine;

public class AI : MonoBehaviour
{
    Rigidbody2D Tank;
    public int Speed;
    void Start()
    {
        Tank = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Tank.linearVelocityX = Speed; 
    }
}
