using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Stats : MonoBehaviour
{
    public TMP_Text personalScoreTextTMP;
    public TMP_Text batteryCounterTMP;
    public TMP_Text canCounterTMP;
    public TMP_Text cartonCounterTMP;
    public TMP_Text flipFlopCounterTMP;
    public TMP_Text ringCounterTMP;

    public void Start()
    {
        getPoints();
    }
    private void getPoints()
    {
        int playerStats = inventory.personalTotalScore;
        personalScoreTextTMP.text = playerStats.ToString();
        int batteryStats = inventory.batteriesTotalScore;
        batteryCounterTMP.text = batteryStats.ToString();
        int canStats = inventory.cansTotalScore;
        canCounterTMP.text = canStats.ToString();
        int cartonStats = inventory.cartonsTotalScore;
        cartonCounterTMP.text = cartonStats.ToString();
        int flipFlopStats = inventory.flipFlopsTotalScore;
        flipFlopCounterTMP.text = flipFlopStats.ToString();
        int ringStats = inventory.ringsTotalScore;
        ringCounterTMP.text = ringStats.ToString();
    }
}
