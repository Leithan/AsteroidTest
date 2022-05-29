public interface IController
{
    IModelView ModelView { get; set; }
    void Init();
    void Update();
    void FixedUpdate();
    void OnCollision();
}