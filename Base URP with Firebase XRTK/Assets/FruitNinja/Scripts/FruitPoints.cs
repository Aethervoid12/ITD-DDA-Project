using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitPoints : MonoBehaviour
{
    public int cutPoints;
    public TextMeshProUGUI ScorePoints;
    public TextMeshProUGUI FinalScore;
    public GameObject MeshDestroy;
    public bool PowerUpBoost = false;

    public AudioSource slashEffect;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Red")
        {
            slashEffect.Play();
            Debug.Log("Cut Red");
            //Change Color (Testing)
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            if (PowerUpBoost == true)
            {
                cutPoints = cutPoints + 4;
            }
            else
            {
                cutPoints = cutPoints + 1;
            }
        }
        if (collider.gameObject.name == "Blue")
        {
            slashEffect.Play();
            Debug.Log("Cut Blue");
            //Change Color (Testing)
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            if (PowerUpBoost == true)
            {
                cutPoints = cutPoints + 4;
            }
            else
            {
                cutPoints = cutPoints + 1;
            }
        }
        if (collider.gameObject.name == "Green")
        {
            slashEffect.Play();
            Debug.Log("Cut Green");
            //Change Color (Testing)
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            if (PowerUpBoost == true)
            {
                cutPoints = cutPoints + 4;
            }
            else
            {
                cutPoints = cutPoints + 1;
            }
        }
        if (collider.gameObject.name == "Black")
        {
            slashEffect.Play();
            Debug.Log("Cut Black");
            //Change Color (Testing)
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            cutPoints = cutPoints - 2;
        }
        if (collider.gameObject.name == "FrostPill")
        {
            slashEffect.Play();
            Debug.Log("Cut FrostPill");
            //Change Color (Testing)
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            if (PowerUpBoost == true)
            {
                cutPoints = cutPoints + 5;
                MeshDestroy.GetComponent<MeshDestroy>().FrostPill();
            }
            else
            {
                cutPoints = cutPoints + 2;
                MeshDestroy.GetComponent<MeshDestroy>().FrostPill();
            }

        }
        if (collider.gameObject.name == "PowerUp")
        {
            slashEffect.Play();
            Debug.Log("Cut Powerup");
            //Change Color (Testing)
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            cutPoints = cutPoints + 5;
            PowerUpBoost = true;
            Invoke("Normal", 10.0f);
        }
    }
    void Update()
    {
        ScorePoints.text = cutPoints.ToString();
        FinalScore.text = cutPoints.ToString();
    }
    public void Restart()
    {
        cutPoints = 0;
    }
    public void Normal()
    {
        PowerUpBoost = false;
    }

}
