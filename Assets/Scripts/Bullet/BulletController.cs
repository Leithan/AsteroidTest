using UnityEngine;

public class BulletController : BaseController
{
    private IBulletModelView modelView;

    private float currentTimeToLive;

    public override void Init()
    {
        modelView = (IBulletModelView)ModelView;
        currentTimeToLive = modelView.TimeToLive;
    }

    public override void Update()
    {
        currentTimeToLive -= TimeProvider.DeltaTime;
        if (currentTimeToLive <= 0.0f)
        {
            OnCollision();
            return;
        }

        Vector3 forwardVector = modelView.Rotation * Vector3.up;
        Vector3 forwardSpeed = forwardVector * (modelView.Speed + modelView.ExtraSpeed) * TimeProvider.DeltaTime;
        modelView.Position += forwardSpeed;
        Vector3 pos = CameraHelper.OnOffScreen(modelView.Position, forwardVector);
        modelView.Position = pos;
    }

    public override void OnCollision()
    {
        Reset();
        modelView.Destroy();
    }

    private void Reset()
    {
        currentTimeToLive = modelView.TimeToLive;
    }
}