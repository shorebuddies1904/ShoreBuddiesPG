using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadScene("ConnectToServer");
    }

    public void playGameFromStart()
    {
        SceneManager.LoadScene("GameScene");
        inventory.batteriesTotalScore = 0;
        inventory.cansTotalScore = 0;
        inventory.cartonsTotalScore = 0;
        inventory.flipFlopsTotalScore = 0;
        inventory.ringsTotalScore = 0;
        inventory.personalTotalScore = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
