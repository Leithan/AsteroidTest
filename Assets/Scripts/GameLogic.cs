using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameLogic : MonoBehaviour
{
    public GameObject HighScoreScreen;
    public GameSettingsSO GameSettings;

    public GameObject ShipInstance { get; set; }
    public int Score { get; set; }
    public static GameLogic Instance;

    // events
    public delegate void IntAction(int val);

    public static event IntAction OnScoreChanged;
    public static event IntAction OnLivesChanged;

    private int currentLives;

    private void Awake()
    {
        Instance = this;
        Score = 0;
        currentLives = GameSettings.MaxLives;
        HighScoreScreen.SetActive(false);
    }

    void Start()
    {
        if (OnLivesChanged != null)
        {
            OnLivesChanged(currentLives);
        }

        // game starts immediately
        SpawnPlayer();
        SpawnAsteroids(5);
        StartCoroutine(SpawnAsteroids());
        StartCoroutine(SpawnEnemyShip());
        TimeProvider.Pause = false;
    }

    private void SpawnPlayer()
    {
        ShipInstance = FactoryProvider<PlayerFactory>.GetFactory().CreatePlayerShip();
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            yield return new WaitForSeconds(GameSettings.TimerForAsteroids);
            if (!TimeProvider.Pause)
            {
                SpawnAsteroids(Random.Range(3, 5));
            }
        }
    }

    private IEnumerator SpawnEnemyShip()
    {
        while (true)
        {
            yield return new WaitForSeconds(GameSettings.TimerForEnemyShip);
            if (!TimeProvider.Pause)
            {
                FactoryProvider<EnemyShipFactory>.GetFactory().CreateEnemy();
            }
        }
    }

    private void SpawnAsteroids(int number)
    {
        for (int index = 0; index < number; index++)
        {
            Vector3 pos = GetPosInsideCamera();
            var randomIndex = Random.Range(0, GameSettings.AsteroidTypes.Count);
            var randomAsteroid = ResourceProvider.Instance.GetResource(GameSettings.AsteroidTypes[randomIndex]);
            FactoryProvider<AsteroidFactory>.GetFactory().CreateAsteroid(randomAsteroid, pos);
        }
    }

    private Vector3 GetPosInsideCamera()
    {
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY, 0f));
        worldPos.z = 0f;
        return worldPos;
    }

    public void UpdateScore(int add)
    {
        Score += add;
        if (OnScoreChanged != null)
        {
            OnScoreChanged(Score);
        }
    }

    public void PlayerDied()
    {
        currentLives--;
        if (currentLives < 0)
        {
            GameOver();
            return;
        }

        if (OnLivesChanged != null)
        {
            OnLivesChanged(currentLives);
        }

        StartCoroutine(StartNewLife());
    }

    private IEnumerator StartNewLife()
    {
        yield return new WaitForSeconds(GameSettings.WaitForRespawn);
        SpawnPlayer();
    }

    private void GameOver()
    {
        int highscore = PlayerPrefs.GetInt("highscore");
        if (highscore > Score)
        {
            GoToMenuScene();
            return;
        }

        HighScoreScreen.SetActive(true);
        TimeProvider.Pause = true;
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void CreateAsteroid(AsteroidType type, Vector3 pos)
    {
        ResourceTypes resourceType;
        switch (type)
        {
            case AsteroidType.Small:
                resourceType = ResourceTypes.AsteroidSmall;
                break;
            case AsteroidType.Medium:
                resourceType = ResourceTypes.AsteroidMedium;
                break;
            case AsteroidType.Large:
                resourceType = ResourceTypes.AsteroidBig;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        var asteroid = ResourceProvider.Instance.GetResource(resourceType);
        FactoryProvider<AsteroidFactory>.GetFactory().CreateAsteroid(asteroid, pos);
    }
}