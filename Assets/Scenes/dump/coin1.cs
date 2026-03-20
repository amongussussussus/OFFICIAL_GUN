using UnityEngine;
using UnityEngine.Events;

public class coin1 : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D coindrop;
    [SerializeField]
    UnityEvent<int> coinCollect;
    [SerializeField]
    int objectID;
    void Start()
    {
        coinCollect.AddListener(GameObject.FindGameObjectWithTag("Logic").GetComponent<score>().AddScore);
        coindrop = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            coinCollect.Invoke(objectID);
            Destroy(gameObject);
        }
        if (collider.CompareTag("Platform"))
        {
            coindrop.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    /*{
        if (collider.CompareTag("Player"))
        {
            coinCollect.Invoke(objectID);
            Destroy(gameObject);
        }
    }*/
}
