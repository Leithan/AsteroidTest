using UnityEngine;

public class PlayerController : BaseController
{
    private IPlayerModelView modelView;

    private float rotationAngle;
    private Vector3 forwardSpeed;
    private Vector3 forwardVector;
    private float waitFireTimer;
    
    public override void Init()
    {
        modelView = (IPlayerModelView)ModelView;
        rotationAngle = 0f;
        modelView.Rotation = Quaternion.Euler(0, 0, rotationAngle);
        forwardVector = modelView.Rotation * Vector3.up;
        waitFireTimer = 0f;
    }

    public void OnRotationClicked(RotationDirection direction)
    {
        float angleDirection = (direction == RotationDirection.Left) ? 1.0f : -1.0f;
        rotationAngle += angleDirection * modelView.rotationAngleSpeed * TimeProvider.DeltaTime;
        modelView.Rotation = Quaternion.Euler(0, 0, rotationAngle);
    }

    public void OnThrustClicked()
    {
        forwardVector = modelView.Rotation * Vector3.up;
        forwardSpeed += forwardVector* modelView.ForwardForce *  TimeProvider.DeltaTime;
        // we clamp magnitude so we dont go too fast
        forwardSpeed = Vector3.ClampMagnitude(forwardSpeed, modelView.MaxSpeed);
        modelView.Speed = forwardSpeed.magnitude;
    }

    public override void Update()
    {
        if(forwardSpeed.sqrMagnitude >= 0)
        {
            forwardSpeed -= forwardSpeed.normalized * modelView.DampingForce *  Time.deltaTime;
        }

        modelView.Position += forwardSpeed;
        Vector3 pos = CameraHelper.OnOffScreen(modelView.Position, forwardVector);
        modelView.Position = pos;
        // Wait a bit before firing again
        waitFireTimer -= TimeProvider.DeltaTime;
    }

    public void OnFire()
    {
        if (waitFireTimer > 0f)
            return;

        FactoryProvider<BulletFactory>.GetFactory().CreateBullet(modelView, EntityType.Player);
        waitFireTimer = modelView.FireTimer;
    }

    public override void OnCollision()
    {
        GameLogic.Instance.PlayerDied();
        modelView.Destroy();
    }
}