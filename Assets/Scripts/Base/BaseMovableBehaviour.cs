using UnityEngine;
using UnityEngine.Serialization;

public class BaseMovableBehaviour : MonoBehaviour, IModelView
{
    public IController Controller { get; set; }

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    public Quaternion Rotation
    {
        get { return transform.rotation; }
        set { transform.rotation = value; }
    }

    [FormerlySerializedAs("_speed")] [SerializeField] private float speed;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    [FormerlySerializedAs("_entityType")] [SerializeField] private EntityType entityType;

    public EntityType EntityType
    {
        get { return entityType; }
        set { entityType = value; }
    }

    public virtual void Destroy()
    {
        Explosion.CreateExplosion(Position);
        Destroy(gameObject);
    }

    public virtual void SetController(IController controller)
    {
        Controller = controller;
        Controller.ModelView = this;
    }
    
    private void Start()
    {
        Controller.Init();
    }

    private void Update()
    {
        Controller.Update();
    }

    private void FixedUpdate()
    {
        Controller.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.OnCollision();
    }
}