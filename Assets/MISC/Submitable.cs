using UnityEngine;
using UnityEngine.InputSystem;

public class Submitable : MonoBehaviour
{
        Cannon cannon;
    void Start()
    {
        cannon = FindAnyObjectByType<Cannon>();
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Cannon>() != null)
        {
            Debug.Log("Loadable");
        }
        if(collision.gameObject.GetComponent<Cannon>() != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            cannon.Loaded();
            Destroy(gameObject);
        }
    }
}
