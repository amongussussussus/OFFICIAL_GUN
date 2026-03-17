using TMPro;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.UI;

public class Cooldowncount : MonoBehaviour
{
    [SerializeField] private TextMeshPro cooldown;
    [SerializeField] private TextMeshPro power_scale;

    Cannon cannon;
    void Awake()
    {
        cannon = GetComponentInParent<Cannon>();
    }
   void Update()
    {
        cooldown.text = "Reload time:" + cannon.Get_time(); 
        power_scale.text = "Power scale:" + cannon.Power_Tuning();
    }
}
