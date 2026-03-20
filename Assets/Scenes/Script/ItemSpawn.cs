using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] spawnItem;//the game item
    public void Spawn(Transform spawnPosition)
    {
        //Spawn the item in spawnItem at a position and rotation that is specified by spawnPosition.
        for(int i=0; i < spawnItem.Length; i++)
        {
            Instantiate(spawnItem[i],spawnPosition.position,spawnPosition.rotation);
        }
    }
}
