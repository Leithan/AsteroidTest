using UnityEngine;

public class AsteroidModelView : BaseMovableBehaviour, IAsteroidModelView
{
    [SerializeField] private int score;

    public int Score
    {
        get => score;
        set => score = value;
    }

    [SerializeField] private AsteroidType asteroidType;

    public AsteroidType AsteroidType
    {
        get => asteroidType;
        set => asteroidType = value;
    }
}