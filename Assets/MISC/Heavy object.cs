using NUnit.Framework;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Heavyobject : MonoBehaviour
{
    Rigidbody2D obj_rb;
    Transform obj;
    bool IsHolded = false;

    void Start()
    {
        obj_rb = GetComponent<Rigidbody2D>();
        obj = GetComponent<Transform>();
        
    }
    void Update()
    {
        if(IsHolded == true)
        Exit();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Lootzone>() != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            obj.transform.SetParent(other.gameObject.transform);
            obj.transform.localPosition = Vector3.zero;
            obj_rb.simulated = false;
            IsHolded = true;
        }
    }
    void Exit()
        {
           if (IsHolded == true && Keyboard.current.eKey.wasPressedThisFrame)
        {
            obj.transform.SetParent(null);
            obj_rb.simulated = true;
            IsHolded = false;
        }
        }
    }
