using UnityEngine;

public class BulletModelView : BaseMovableBehaviour, IBulletModelView
{
    [SerializeField] private float timeToLive;
    private BulletController _controller;

    public float TimeToLive 
    {
        get => timeToLive;
        set => timeToLive = value;
    }

    public override void Destroy()
    {
        Destroy(gameObject);
    }
}