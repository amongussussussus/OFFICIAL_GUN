using UnityEngine;

public class Lightobject : MonoBehaviour
{
    Rigidbody2D obj_rb;
    void Start()
    {
        obj_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.GetComponent<Movingandcrouch>() != null)
        {
            Debug.Log("Add to the inventory");
            Destroy(gameObject);
        }
    }
}
