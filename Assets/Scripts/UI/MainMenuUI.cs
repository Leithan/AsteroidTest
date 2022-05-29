using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public Text highScore;
    public Text highScoreName;

    // Use this for initialization
    void Start()
    {
        int score = PlayerPrefs.GetInt("highscore");
        string name = PlayerPrefs.GetString("name");
        highScore.text = "" + score;
        highScoreName.text = "" + name;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}