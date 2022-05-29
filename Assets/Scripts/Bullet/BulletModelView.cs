using UnityEngine;

public class BulletModelView : BaseMovableBehaviour, IBulletModelView
{
    [SerializeField] private float timeToLive;
    public bool Dead { get; set; }
    public float ExtraSpeed { get; set; }

    public float TimeToLive 
    {
        get => timeToLive;
        set => timeToLive = value;
    }

    public override void Destroy()
    {
        Dead = true;
        gameObject.SetActive(false);
    }
}