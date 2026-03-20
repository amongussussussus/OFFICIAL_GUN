using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using NUnit.Framework;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Cannon : MonoBehaviour
{
    private Transform Barrel;
    float angle = 0;
    public GameObject prefab;
    bool IsSummon =  true;
    float timer = 4;
    public int Power_scale = 0;
    Movingandcrouch player;
    Animator animator;
    bool IsLoaded = false;
    private void Awake()
    {
        player = FindAnyObjectByType<Movingandcrouch>();
        Barrel = GetComponent<Transform>();
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        if (player.Get_Manned() == true)
        SummonProjectile();
        Power_Tuning();
    }
    private void FixedUpdate()
    {
         if (player.Get_Manned() == true)
         {
             Barrel.transform.rotation = UnityEngine.Quaternion.Euler(0,0,CannonLeverage());
         }      
        if (timer > 0)
        timer -=1*Time.deltaTime;

    }
    public float CannonLeverage()
    {
        float max_angle = 45;
        float turnSpeed = 5f;
        if(Keyboard.current.wKey.IsPressed() && angle <= max_angle)
        {
            angle += turnSpeed*Time.deltaTime;
    
        }
        if(Keyboard.current.sKey.IsPressed())
        {
            angle -= turnSpeed*Time.deltaTime;
    
        }
        return angle;
    }
   private void SummonProjectile()
    {
        if(Keyboard.current.spaceKey.IsPressed() && timer <= 0 && IsLoaded == true)
        {
            animator.SetTrigger("Fire");
            GameObject  bullet =  Instantiate(prefab, Barrel.transform.position,UnityEngine.Quaternion.Euler(Barrel.transform.eulerAngles + new UnityEngine.Vector3(0,0,-90)),Barrel);
            Debug.Log("Summon");
            timer = 4;
            IsLoaded = false;

    }
    }
    public float Get_time()
    {
        float time = timer;
        return time;
    }
    public int Power_Tuning()
    {
        if(Keyboard.current.upArrowKey.wasPressedThisFrame && Power_scale>=0)
        {
           Power_scale = Power_scale + 10;
           Debug.Log("UP");
        }
        
        if(Keyboard.current.downArrowKey.wasPressedThisFrame && Power_scale>=0)
        {
           Power_scale -= 10;
           Debug.Log("Down");
        }
        if(Power_scale <= 0)
        {
            Power_scale = 0;
        }
        return Power_scale;
    }
    public UnityEngine.Vector2 ReturnAngle()
    {
        UnityEngine.Vector2 velocity_angle;
        velocity_angle = new UnityEngine.Vector2(Mathf.Cos(angle * Mathf.Deg2Rad),Mathf.Sin(angle * Mathf.Deg2Rad));
        return velocity_angle;
    }
    public void Loaded()
    {
        IsLoaded = true;
        animator.SetTrigger("Loading");
    }
}
