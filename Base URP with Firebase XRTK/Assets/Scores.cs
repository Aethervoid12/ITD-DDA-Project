public class Scores
{
    public string username;
    public int highScore;
    public int leaderboardDate;
    public Scores()
    {
    }

    public Scores(string username, int highScore, int leaderboardDate)
    {
        this.username = username;
        this.highScore = highScore;
        this.leaderboardDate = leaderboardDate;
    }
}

