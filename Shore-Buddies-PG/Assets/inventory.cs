using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class inventory : MonoBehaviour
{
    public TMP_Text personalScoreText;
    public TMP_Text groupScoreText;
    int personalScore = 0, groupScore = 0;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spawnable")) 
        {
            Collect(other.GetComponent<Collectible>());
        }
    }

    public void UpdateTextBox() {
        personalScoreText.text = personalScore.ToString();
        groupScoreText.text = $"Score: {groupScore.ToString()}";
    }

    private void Collect (Collectible collectible)
    {
        if(collectible.Collect())
        {
            if(collectible is batteryCollectible)
            {
                Debug.Log("battery collected");
                personalScore += 20;
                groupScore += 20;
            }
            else if(collectible is flipFlopCollectible)
            {
                Debug.Log("flip flop collected");
                personalScore += 5;
                groupScore += 5;
            }
            else if(collectible is cartonCollectible)
            {
                Debug.Log("carton collected");
                personalScore += 10;
                groupScore += 10;
            }
            else if(collectible is ringCollectible)
            {
                Debug.Log("ring collected");
                personalScore += 10;
                groupScore += 10;
            }
            else if(collectible is canCollectible)
            {
                Debug.Log("can collected");
                personalScore += 5;
                groupScore += 5;
            }
            else
            {
                Debug.Log("Nothing Collected");
            }
            
        }
        UpdateTextBox();
    }

}
