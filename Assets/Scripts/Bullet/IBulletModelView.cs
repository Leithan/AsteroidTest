public interface IBulletModelView : IModelView
{
    float TimeToLive { get; set; }
    bool Dead { get; set; }
    float ExtraSpeed { get; set; }
}