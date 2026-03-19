using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ParticlePickup : MonoBehaviour
{
    //This script calls the AddScore function when the player (object with tag "Player") made contact with the item (particle).
    //In order to destroy the item when the player collect it, set the Inside of Trigger atribute to Kill.
   [SerializeField]
   ParticleSystem itemDrop;
   [SerializeField]
   UnityEvent<int> coinCollect;
   [SerializeField]
   int itemIndex;
   float liveTime=0;
   List<ParticleSystem.Particle> exit = new List<ParticleSystem.Particle>();
   
    void Start()
    {
        itemDrop = GetComponent<ParticleSystem>();
        coinCollect.AddListener(GameObject.FindGameObjectWithTag("Logic").GetComponent<score>().AddScore);
        liveTime = Time.time;
        itemDrop.trigger.AddCollider(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        
    }
    void Update()
    {
        //Destroy the Particle System after its duration has ended
        if(Time.time - liveTime >= itemDrop.main.duration)
        {
            Destroy(gameObject);
        }
    }
    void OnParticleTrigger()
    {
       int numExit = itemDrop.GetTriggerParticles(ParticleSystemTriggerEventType.Enter,exit);
       for (int i = 0; i < numExit; i++)
        {
            coinCollect.Invoke(itemIndex);
            Debug.Log(i);
            
        }
        
    }
}
