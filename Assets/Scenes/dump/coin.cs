using UnityEngine;
using UnityEngine.Events;

public class coin : MonoBehaviour
{
    [SerializeField]
    UnityEvent<int> coinCollect;
    [SerializeField]
    int objectID;
    void Start()
    {
        coinCollect.AddListener(GameObject.FindGameObjectWithTag("Logic").GetComponent<score>().AddScore);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            coinCollect.Invoke(objectID);
            Destroy(gameObject);
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
