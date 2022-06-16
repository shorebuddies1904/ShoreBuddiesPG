using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class inventory : MonoBehaviour
{
    public TMP_Text scoreText;
    int score = 0; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spawnable")) 
        {
            Collect(other.GetComponent<Collectible>());
        }
    }

    public void UpdateTextBox() {
        scoreText.text = score.ToString();
    }

    private void Collect (Collectible collectible)
    {
        if(collectible.Collect())
        {
            if(collectible is batteryCollectible)
            {
                Debug.Log("battery collected");
                score += 20;
            }
            else if(collectible is flipFlopCollectible)
            {
                Debug.Log("flip flop collected");
                score += 5;
            }
            else if(collectible is cartonCollectible)
            {
                Debug.Log("carton collected");
                score += 10;
            }
            else if(collectible is ringCollectible)
            {
                Debug.Log("ring collected");
                score += 10;
            }
            else if(collectible is canCollectible)
            {
                Debug.Log("can collected");
                score += 5;
            }
            else
            {
                Debug.Log("Nothing Collected");
            }
            
        }
        UpdateTextBox();
    }

}
