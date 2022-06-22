using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class inventory : MonoBehaviour
{
    float inputHorizontal, inputVertical;
    Rigidbody2D rb;
    public TMP_Text personalScoreText;
    public TMP_Text groupScoreText;
    public TMP_Text batteryCounter;
    public TMP_Text canCounter;
    public TMP_Text cartonCounter;
    public TMP_Text flipFlopCounter;
    public TMP_Text ringCounter;
    private int batteries = 0;
    private int cans = 0;
    private int cartons = 0;
    private int flipFlops = 0;
    private int rings = 0;
    
    int personalScore = 0, groupScore = 0;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spawnable")) 
        {
            Collect(other.GetComponent<Collectible>());
        }
    }

    public void UpdateTextBox() 
    {
        personalScoreText.text = personalScore.ToString();
        groupScoreText.text = groupScore.ToString();
    }

    private void Collect (Collectible collectible)
    {
        if(collectible.Collect())
        {
            if(collectible is batteryCollectible)
            {
                Debug.Log("battery collected");
                batteries++;
                personalScore += 1;
                groupScore += 1;
            }
            else if(collectible is flipFlopCollectible)
            {
                Debug.Log("flip flop collected");
                flipFlops++;
                personalScore += 1;
                groupScore += 1;
            }
            else if(collectible is cartonCollectible)
            {
                Debug.Log("carton collected");
                cartons++;
                personalScore += 1;
                groupScore += 1;
            }
            else if(collectible is ringCollectible)
            {
                Debug.Log("ring collected");
                rings++;
                personalScore += 1;
                groupScore += 1;
            }
            else if(collectible is canCollectible)
            {
                Debug.Log("can collected");
                cans++;
                personalScore += 1;
                groupScore += 1;
            }
            else
            {
                Debug.Log("Nothing Collected");
            }
            
        }
        UpdateGUI();
        UpdateTextBox();
    }
    private void UpdateGUI()
    {
        batteryCounter.text = batteries.ToString();
        canCounter.text = cans.ToString();
        cartonCounter.text = cartons.ToString();
        flipFlopCounter.text = flipFlops.ToString();
        ringCounter.text = rings.ToString();
    }

    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(0.15f,0.15f,0.7f);
        }
        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(-0.15f,0.15f,0.7f);
        }
    }
}