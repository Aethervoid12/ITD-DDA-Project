using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;

public class FruitPoints : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;
    DatabaseReference mDatabaseRef;
    DatabaseReference dbPlayerStatsReference;
    /// ///////////////////////////////////////////
    int cutPoints;
    public TextMeshProUGUI ScorePoints;
    public TextMeshProUGUI FinalScore;
    public GameObject MeshDestroy;
    public bool PowerUpBoost = false;
    int highScore = 0;
    /// ///////////////////////////////////////////
    int leaderboardDate;
    string username;
    string userID;
    public AudioSource slashEffect;

    public GameObject SlashItManager;

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        dbPlayerStatsReference = FirebaseDatabase.DefaultInstance.GetReference("fruitSlashHighScores");
    }
    void OnTriggerEnter(Collider collider)
    {
        // Check to see if which projectile did the blade collide with.
        //Different projectiles will have different effects on the game.
        //RGB Cube are normal and give you 1 point each.
        //Frost Pill causes the projectiles to slowly fall.
        //PowerUp Pill gives double the points.
        if (collider.gameObject.tag == "Red")
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
        if (collider.gameObject.tag == "Blue")
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
        if (collider.gameObject.tag == "Green")
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
        if (collider.gameObject.tag == "Black")
        {
            slashEffect.Play();
            Debug.Log("Cut Black");
            //Change Color (Testing)
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            cutPoints = cutPoints - 2;
        }
        if (collider.gameObject.tag == "FrostPill")
        {
            slashEffect.Play();
            Debug.Log("Cut FrostPill");
            //Change Color (Testing)
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            if (PowerUpBoost == true)
            {
                cutPoints = cutPoints + 5;
                SlashItManager.GetComponent<SlashItManager>().FrostPill();
            }
            else
            {
                cutPoints = cutPoints + 2;
                SlashItManager.GetComponent<SlashItManager>().FrostPill();
            }

        }
        if (collider.gameObject.tag == "PowerUp")
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
    //Updating the scores in the text.
    void Update()
    {
        ScorePoints.text = cutPoints.ToString();
        FinalScore.text = cutPoints.ToString();
    }
    //Reset for new game.
    public void Restart()
    {
        cutPoints = 0;
    }
    //Function for when the PowerUp Boost ran out.
    public void Normal()
    {
        PowerUpBoost = false;
    }
    //Register the new scores.
    private void WriteNewScore(string userId, string username, int highScore, int leaderboardDate)
    {
        Scores score = new Scores(username, highScore, leaderboardDate);
        string json = JsonUtility.ToJson(score);

        mDatabaseRef.Child("fruitSlashHighScores").Child(userId).SetRawJsonValueAsync(json);
    }
    public void RecordPoints()
    {
        Firebase.Auth.FirebaseUser currentUser = auth.CurrentUser;
        Debug.Log("User Recorded");
        if (currentUser != null)
        {
            userID = currentUser.UserId;
            username = currentUser.DisplayName;
            Debug.Log(username + userID);
            dbPlayerStatsReference.Child(userID).Child("highScore").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                Debug.Log("Database Recorded");
                if (task.IsFaulted)
                {
                    Debug.LogWarning(message: $"Failed to register task");
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    highScore = int.Parse(snapshot.GetRawJsonValue());
                }
            });
            if (cutPoints >= highScore)
            {
                highScore = cutPoints;
                var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                leaderboardDate = (int)timestamp;
                WriteNewScore(userID, username, highScore, leaderboardDate);
                Debug.Log(userID + " + " + username + " + " + highScore);

            }

        }
    }


}
