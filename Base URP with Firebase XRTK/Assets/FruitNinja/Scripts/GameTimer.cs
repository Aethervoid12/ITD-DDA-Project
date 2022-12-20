using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    //Set the first game timer at the Inspector.
    //Set the second timer after the reset is at below "else" timeValue.
    public float timeValue;
    public TextMeshProUGUI timeText;
    public GameObject SlashItManager;
    public GameObject FruitSpawner;
    public GameObject SlowFruitSpawner;
    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            //**Here**//
            timeValue = 60;
        }

        DisplayTime(timeValue);

        //When the countdwon reach 15, something special will happen.
        if (timeValue < 15)
        {
            //End game scenario.
            FruitSpawner.GetComponent<FruitSpawner>().FinalGame();
            SlowFruitSpawner.GetComponent<SlowFruitSpawner>().FinalGame();
        }
    }

    //Function for timer countdown.
    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
            SlashItManager.GetComponent<SlashItManager>().EndGame();
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    //Reset the game not only the score but also the timing.
    public void RestartTime()
    {
        timeValue = 60;
        DisplayTime(timeValue);
    }
}
