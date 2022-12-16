using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayGame: MonoBehaviour
{
    public GameObject BaseballPrefab;
    public GameObject TincanPrefab;
    public Transform BaseballPosition;
    public Transform TincanPosition;
    public GameObject GameoverMessage;

    //Starts spawning tin cans and baseballs when the player enters player detection zone
    void BeginRound()
    {
        Debug.Log("Game Started");
        Instantiate(BaseballPrefab, BaseballPosition.position, Quaternion.identity);
        Instantiate(TincanPrefab, TincanPosition.position, Quaternion.identity);
    }

    //Ends game when the player automatically leaves the player detection zone
    void EndGame()
    {
        Destroy(gameObject);
        GameoverMessage.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            BeginRound();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            EndGame();
        }
    }
}
