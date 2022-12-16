using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashItManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject FruitSpawner;
    public GameObject Timer;
    public GameObject Score;
    public GameObject FinalScore;

    public void StartGame()
    {
        StartMenu.SetActive(false);
        Timer.SetActive(true);
        Score.SetActive(true);
        FinalScore.SetActive(false);
        FruitSpawner.SetActive(true);
        FruitSpawner.GetComponent<FruitSpawner>().StartGame();
    }
    public void EndGame()
    {
        StartMenu.SetActive(false);
        Timer.SetActive(false);
        Score.SetActive(false);
        FinalScore.SetActive(true);
        FruitSpawner.SetActive(false);

    }
}
