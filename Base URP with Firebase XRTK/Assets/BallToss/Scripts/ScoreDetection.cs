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

public class ScoreDetection : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;
    DatabaseReference mDatabaseRef;
    DatabaseReference dbPlayerStatsReference;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI baseballLeftText;
    //Checks the number of tin cans that collides with the score detection zone
    int cansKnockOut = 0;
    //Checks the number of baseball used (max 3)
    int baseballUsed = 0;
    //Checks the number of baseball left 
    int baseballLeft = 3;
    //Check the score of the player
    int score = 0;
    public GameObject GameoverMessage;
    public GameObject BaseballPrefab;
    public GameObject TincanPrefab;
    public bool IsGameActive;
    int highScore = 0;
    int leaderboardDate;
    string username;
    string userID;
    //Respawn objects when player is allowed to continue next round

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
        mDatabaseRef = FirebaseDatabase.DefaultInstance.RootReference;
        dbPlayerStatsReference = FirebaseDatabase.DefaultInstance.GetReference("ballTossHighScores");
        IsGameActive = true;
    }

    void ContinueGame()
    {
        Instantiate(BaseballPrefab, transform.position, Quaternion.identity);
        Instantiate(TincanPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if the tin can collides with the score detection zone
        if(other.tag == "TinCan")
        {
            //Increase the number of tin can by 1
            ++cansKnockOut;
            //Increase the player score by 5
            score += 5;
            //Attach this score to the score text
            scoreText.text = "Current Score: " + score.ToString();
        }

        //Check if the baseball collides with the score detection zone
        if(other.tag == "Baseball")
        {
            //Increase the number of baseball used by 1
            ++baseballUsed;
            //Decrease the number of baseball left by 1
            --baseballLeft;
            //Attach this value to the baseball left text
            baseballLeftText.text = "Baseball Left: " + baseballLeft.ToString();
            if (baseballUsed == 3)
            {
                //Display game over message
                Debug.Log("Game Ended");
                EndGame();
            }
        }
       
    }
    private void WriteNewScore(string userId, string username, int highScore, int leaderboardDate)
    {
        Scores score = new Scores(username, highScore, leaderboardDate);
        string json = JsonUtility.ToJson(score);

        mDatabaseRef.Child("ballTossHighScores").Child(userId).SetRawJsonValueAsync(json);
    }

    void EndGame()
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
            if (score >= highScore)
            {
                highScore = score;
                var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
                var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
                leaderboardDate = (int)timestamp;
                WriteNewScore(userID, username, highScore, leaderboardDate);
                Debug.Log(userID + " + " + username + " + " + highScore);

            }

        }
    }
}
