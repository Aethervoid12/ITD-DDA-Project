using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using Firebase.Extensions;
using System.Linq;

public class ScoreboardData : MonoBehaviour
{
    Firebase.Auth.FirebaseAuth auth;
    DatabaseReference DBReference;

    public GameObject scoreElement;
    public Transform scoreboardContent;
    public GameObject setScore;

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
        DBReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Update()
    {
        BeginScoreBoardLoad();
    }

    public void BeginScoreBoardLoad()
    {
        StartCoroutine(LoadScoreboardData());
    }

    private IEnumerator LoadScoreboardData()
    {
        //collects score data from firebase, then converts it into data displayable on the Unity Scoreboard
        var DBTask = DBReference.Child("ballTossHighScores").OrderByChild("highScore").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            DataSnapshot snapshot = DBTask.Result;

            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                string username = childSnapshot.Child("username").Value.ToString();
                int highscore = int.Parse(childSnapshot.Child("highScore").Value.ToString());

                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, highscore);
            }
        }
    }

}