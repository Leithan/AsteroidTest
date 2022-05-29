using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;

    private void OnEnable()
    {
        GameLogic.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        GameLogic.OnScoreChanged -= UpdateScore;
    }

    private void UpdateScore(int score)
    {
        scoreText.text = "" + score;
    }
}