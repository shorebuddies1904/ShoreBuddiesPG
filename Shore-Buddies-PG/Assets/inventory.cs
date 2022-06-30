using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using Photon.Pun;

public class inventory : MonoBehaviour
{
    float inputHorizontal, inputVertical;
    Rigidbody2D rb;
    SpriteRenderer rend;
    public TMP_Text personalScoreText;
    public TMP_Text groupScoreText;
    public TMP_Text batteryCounter;
    public TMP_Text canCounter;
    public TMP_Text cartonCounter;
    public TMP_Text flipFlopCounter;
    public TMP_Text ringCounter;
    public int inventorySize = 5;
    public int personalScore = 0;
    public int groupScore = 0;
    private int batteries = 0;
    private int cans = 0;
    private int cartons = 0;
    private int flipFlops = 0;
    private int rings = 0;
    private int batteriesTotal = 0;
    private int cansTotal = 0;
    private int cartonsTotal = 0;
    private int flipFlopsTotal = 0;
    private int ringsTotal = 0;
    public static int personalTotalScore = 0;
    public static int batteriesTotalScore = 0;
    public static int cansTotalScore = 0;
    public static int cartonsTotalScore = 0;
    public static int flipFlopsTotalScore = 0;
    public static int ringsTotalScore = 0;
    public static int groupTotalScore = 0;

    PhotonView view;
    
    [PunRPC]
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        personalScoreText = GameObject.Find("HeldItems").GetComponent<TextMeshProUGUI>();
        groupScoreText = GameObject.Find("TotalScore").GetComponent<TextMeshProUGUI>();
        batteryCounter = GameObject.Find("BatteryCounter").GetComponent<TextMeshProUGUI>();
        cartonCounter = GameObject.Find("CartonCounter").GetComponent<TextMeshProUGUI>();
        canCounter = GameObject.Find("CanCounter").GetComponent<TextMeshProUGUI>();
        flipFlopCounter = GameObject.Find("FFCounter").GetComponent<TextMeshProUGUI>();
        ringCounter = GameObject.Find("RingCounter").GetComponent<TextMeshProUGUI>();
        rend = GetComponent<SpriteRenderer>();
        view = GetComponent<PhotonView>();
        UpdateGUI();
        UpdateTextBox();
    }
    [PunRPC]
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Spawnable") && (personalScore < inventorySize)) 
        {
            Collect(other.GetComponent<Collectible>());
        }

        if(personalScore == inventorySize)
        {
            rend.color = Color.gray;
        }
        else
        {
            rend.color = Color.white;
        }

        if(other.CompareTag("Deposit"))
        {
            groupScore = groupScore + batteries + cans + cartons + flipFlops + rings;
            personalTotalScore = groupScore;
            personalScore = 0;
            batteries = 0;
            cans = 0;
            cartons = 0;
            flipFlops = 0;
            rings = 0;
        }
    }
    [PunRPC]
    public void UpdateTextBox() 
    {
        //personalScoreText.text = $"{personalScore.ToString()} / " + inventorySize;
        //groupScoreText.text = groupScore.ToString();

    }

    [PunRPC]
    private void Collect (Collectible collectible)
    {
        if(collectible.Collect())
        {
            if(collectible is batteryCollectible)
            {
                Debug.Log("battery collected");
                batteries++;
                batteriesTotal++;
                batteriesTotalScore++;
                personalScore += 1;
                personalTotalScore++;
                //groupScore += 1;
            }
            else if(collectible is flipFlopCollectible)
            {
                Debug.Log("flip flop collected");
                flipFlops++;
                flipFlopsTotal++;
                flipFlopsTotalScore++;
                personalScore += 1;
                personalTotalScore++;
                //groupScore += 1;
            }
            else if(collectible is cartonCollectible)
            {
                Debug.Log("carton collected");
                cartons++;
                cartonsTotal++;
                cartonsTotalScore++;
                personalScore += 1;
                personalTotalScore++;
                //groupScore += 1;
            }
            else if(collectible is ringCollectible)
            {
                Debug.Log("ring collected");
                rings++;
                ringsTotal++;
                ringsTotalScore++;
                personalScore += 1;
                personalTotalScore++;
                //groupScore += 1;
            }
            else if(collectible is canCollectible)
            {
                Debug.Log("can collected");
                cans++;
                cansTotal++;
                cansTotalScore++;
                personalScore += 1;
                personalTotalScore++;
                //groupScore += 1;
            }
            else
            {
                Debug.Log("Nothing Collected");
            }
            
        }
        UpdateGUI();
        UpdateTextBox();
    }
    [PunRPC]
    private void UpdateGUI()
    {
        batteryCounter.text = batteriesTotalScore.ToString();
        canCounter.text = cansTotalScore.ToString();
        cartonCounter.text = cartonsTotalScore.ToString();
        flipFlopCounter.text = flipFlopsTotalScore.ToString();
        ringCounter.text = ringsTotalScore.ToString();
        personalScoreText.text = $"{personalScore.ToString()} / " + inventorySize;
        groupScoreText.text = groupScore.ToString();

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

        view.RPC("Start", RpcTarget.AllBufferedViaServer);
        view.RPC("Collect", RpcTarget.AllBufferedViaServer);
        view.RPC("OnTriggerStay2D", RpcTarget.AllBufferedViaServer);
        view.RPC("UpdateTextBox", RpcTarget.AllBufferedViaServer);
        view.RPC("UpdateGUI", RpcTarget.AllBufferedViaServer);
        view.RPC("reset", RpcTarget.AllBufferedViaServer);
            


        UpdateGUI();
        UpdateTextBox();
    }
}