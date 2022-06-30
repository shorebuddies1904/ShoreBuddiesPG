using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro; 
using UnityEngine.UI;
public class BetterScore : MonoBehaviour
{
    int score = 0;
    PhotonView view;
    public TMP_Text scoreDisplay;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void AddScore()
    {
        view.RPC("AddScoreRPC", RpcTarget.All);
    }

    [PunRPC]
    void AddScoreRPC()
    {
        score++;
        scoreDisplay.text = score.ToString();
    }
}
