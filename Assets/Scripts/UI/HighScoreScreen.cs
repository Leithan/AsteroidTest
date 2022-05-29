using UnityEngine;
using UnityEngine.UI;

public class HighScoreScreen : MonoBehaviour
{
    public Text scoreText;
    public Text Name;
    private const string nameField = "name";
    private const string scoreField = "highscore";

    private void OnEnable()
    {
        if (GameLogic.Instance == null)
        {
            return;
        }
        scoreText.text = "" + GameLogic.Instance.Score;
    }

    public void Replay()
    {
        PlayerPrefs.SetString(nameField, Name.text);
        PlayerPrefs.SetInt(scoreField, GameLogic.Instance.Score);
        PlayerPrefs.Save();
        GameLogic.Instance.GoToMenuScene();
    }
}