using UnityEngine;
using UnityEngine.Events;

public class ItemValue : MonoBehaviour
{
    [SerializeField]
    int coinCost;
    [SerializeField]
    int materialCost;
    [SerializeField]
    UnityEvent decreaseMaterial;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
