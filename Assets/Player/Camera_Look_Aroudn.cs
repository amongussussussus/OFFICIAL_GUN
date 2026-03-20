using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Camera_Look_Aroudn : MonoBehaviour
{
    Camera camera1;
    void Start()
    {
        camera1 = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos += new UnityEngine.Vector3(0,0,-13);
        if(Mouse.current.rightButton.isPressed)
        {
            camera1.transform.position = UnityEngine.Vector3.MoveTowards(camera1.transform.position,mousePos,1);
        }   
        else
        {
            camera1.transform.localPosition = new UnityEngine.Vector3(0,0,-13);
        }
          camera1.transform.rotation = UnityEngine.Quaternion.Euler(0,0,0);
    }
  
}
