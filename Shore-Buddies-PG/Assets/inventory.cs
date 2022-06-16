using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spawnable")) 
        {
            Collect(other.GetComponent<Collectible>());
        }
    }

    private void Collect (Collectible collectible)
    {
        if(collectible.Collect())
        {
            if(collectible is batteryCollectible)
            {
                Debug.Log("battery collected");
            }
            else if(collectible is flipFlopCollectible)
            {
                Debug.Log("flip flop collected");
            }
            else if(collectible is cartonCollectible)
            {
                Debug.Log("carton collected");
            }
            else if(collectible is ringCollectible)
            {
                Debug.Log("ring collected");
            }
             else if(collectible is canCollectible)
            {
                Debug.Log("can collected");
            }
            else
            {
                Debug.Log("Nothing Collected");
            }
        }
        
    }
}
