public abstract class BaseController : IController
{
    public IModelView ModelView { get; set; }

    public virtual void Init()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void FixedUpdate()
    {
    }

    public virtual void OnCollision()
    {
    }
}