using UnityEngine;

public class AsteroidController : BaseController
{
    private IAsteroidModelView modelView;

    private Vector3 forwardVector;

    public override void Init()
    {
        modelView = (IAsteroidModelView)ModelView;
        modelView.Rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        forwardVector = modelView.Rotation * Vector3.up;
    }

    public override void Update()
    {
        Vector3 forwardSpeed = forwardVector * modelView.Speed * TimeProvider.DeltaTime;
        modelView.Position += forwardSpeed;
        Vector3 angle = modelView.Rotation.eulerAngles;
        angle.z += Random.Range(5f, 10f) * TimeProvider.DeltaTime;
        modelView.Rotation = Quaternion.Euler(angle);
    }

    public override void FixedUpdate()
    {
        Vector3 pos = CameraHelper.OnOffScreen(modelView.Position, forwardVector);
        modelView.Position = pos;
    }

    public override void OnCollision()
    {
        GameLogic.Instance.UpdateScore(modelView.Score);
        //Create more childs if needed
        switch (modelView.AsteroidType)
        {
            case AsteroidType.Large:
                for (int i = 0; i < 2; i++)
                {
                    GameLogic.Instance.CreateAsteroid(AsteroidType.Medium, modelView.Position);
                }
                break;
            case AsteroidType.Medium:
                for (int i = 0; i < 2; i++)
                {
                    GameLogic.Instance.CreateAsteroid(AsteroidType.Small, modelView.Position);
                }
                break;
        }

        modelView.Destroy();
    }
}