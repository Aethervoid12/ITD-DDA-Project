using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashItManager : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject FruitSpawner;
    public GameObject SlowFruitSpawner1;
    public GameObject SlowFruitSpawner2;
    public GameObject Timer;
    public GameObject Score;
    public GameObject FinalScore;
    public GameObject FruitPoints;

    //Function GameManager of Starting of the game.
    public void StartGame()
    {
        StartMenu.SetActive(false);
        Timer.SetActive(true);
        Score.SetActive(true);
        FinalScore.SetActive(false);
        FruitSpawner.SetActive(true);
        FruitSpawner.GetComponent<FruitSpawner>().StartGame();
    }
    //Function for when the games as ended.
    public void EndGame()
    {
        StartMenu.SetActive(false);
        Timer.SetActive(false);
        Score.SetActive(false);
        FinalScore.SetActive(true);
        FruitSpawner.SetActive(false);
        FruitPoints.GetComponent<FruitPoints>().RecordPoints();
    }
    //Function for what happens when player slash a frostpill.
    public void FrostPill()
    {
        FruitSpawner.SetActive(false);
        SlowFruitSpawner1.SetActive(true);
        SlowFruitSpawner2.SetActive(true);

        SlowFruitSpawner1.GetComponent<SlowFruitSpawner>().StartGame();
        SlowFruitSpawner2.GetComponent<SlowFruitSpawner>().StartGame();
        Invoke("Normal", 5.0f);
    }
    //Revert everything to normal after slashing FrostPill.
    public void Normal()
    {
        FruitSpawner.SetActive(true);
        SlowFruitSpawner1.SetActive(false);
        SlowFruitSpawner2.SetActive(false);

        FruitSpawner.GetComponent<FruitSpawner>().StartGame();
    }
}
