using System.Threading;
using UnityEngine;

public class Damage_zone: NewMonoBehaviourScript
{
    float timer = 2f;
    void Update()
    {
        timer -= 1*Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
