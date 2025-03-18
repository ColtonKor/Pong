using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI lefthighScore;
    public GameObject leftWinner;
    public GameObject rightWinner;
    public Transform ball;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;

    private int leftPlayerScore = 0;
    private int rightPlayerScore = 0;
    private int Multiply = 1;
    private Vector3 ballStartPos;
    private const int scoreToWin = 11;
    private int highscore = 0;
    private int Lefthighscore = 0;


    // Start is called before the first frame update
    void Start()
    {
        score.color = new Color(255, 255, 255, 255);
        score.text = leftPlayerScore.ToString() + " : " + rightPlayerScore.ToString();
        highScore.text = "Right High Score: " + highscore.ToString();
        lefthighScore.text = "Left High Score: " + Lefthighscore.ToString();
        leftWinner.SetActive(false);
        rightWinner.SetActive(false);
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.linearVelocity = new Vector3(1f, 0f, 0f) * startSpeed;
    }

    // If the ball entered the goal area, increment the score, check for win, and reset the ball
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        if (trigger == leftGoalTrigger)
        {
            rightWinner.SetActive(false);
            rightPlayerScore += Multiply;
            SetCountText();
            if (rightPlayerScore > highscore){
                highscore = rightPlayerScore;
                highScore.text = "Right High Score: " + highscore.ToString();
            }
            // Debug.Log($"Right player scored: {rightPlayerScore}");
            if (rightPlayerScore == scoreToWin)
            {
                rightPlayerScore = 0;
                leftPlayerScore = 0;
                rightWinner.SetActive(true);
                SetCountText();
                ResetBall(1f);
                // Debug.Log("Right player wins!");
            }
            else
            {
                ResetBall(1f);
            }
        }
        else if (trigger == rightGoalTrigger)
        {
            leftWinner.SetActive(false);
            leftPlayerScore += Multiply;
            SetCountText();
            if(leftPlayerScore > Lefthighscore){
                Lefthighscore = leftPlayerScore;
                lefthighScore.text = "Left High Score: " + Lefthighscore.ToString();
            }
            // Debug.Log($"Left player scored: {leftPlayerScore}");
            if (leftPlayerScore == scoreToWin)
            {
                rightPlayerScore = 0;
                leftPlayerScore = 0;
                leftWinner.SetActive(true);
                SetCountText();
                ResetBall(-1f);
                // Debug.Log("Left player wins!");
            }
            else
            {
                ResetBall(-1f);
            }
        }
    }

    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.linearVelocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }

    void SetCountText()
	{
        score.color = new Color32((byte)Random.Range(1, 255), (byte)Random.Range(1, 255), (byte)Random.Range(1, 255), 255);
		score.text = leftPlayerScore.ToString() + " : " + rightPlayerScore.ToString();
	}

    public void ScoreUpdate(int score){
        Multiply = score;
    }

    // void ScoreHigh(int score){
    //     highScore.text = "Right High Score: " + score.ToString();
    // }
}
