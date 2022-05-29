using UnityEngine;

public class EnemyShipModelView : BaseMovableBehaviour, IEnemyShipModelView
{
    [SerializeField] private float fireTimer;

    public float FireTimer 
    {
        get => fireTimer;
        set => fireTimer = value;
    }

    [SerializeField] private int score;

    public int Score
    {
        get => score;
        set => score = value;
    }
}