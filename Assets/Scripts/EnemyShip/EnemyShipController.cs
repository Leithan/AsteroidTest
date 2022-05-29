
using UnityEngine;

public class EnemyShipController : BaseController
{
    private IEnemyShipModelView modelView;

    private float waitFireTimer;
    private readonly Vector3 leftDirection = new Vector3(-1f, 0f, 0f);

    public override void Init()
    {
        modelView = (IEnemyShipModelView)ModelView;
        float posX = Random.Range(0.1f, 0.9f);
        float posY = Random.Range(0.1f, 0.9f);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(posX, posY, 0f));
        worldPos.z = 0f;
        modelView.Position = worldPos;
        waitFireTimer = modelView.FireTimer;
    }

    public override void Update()
    {
        // always go to the left
        Vector3 speed = leftDirection * modelView.Speed * TimeProvider.DeltaTime;
        modelView.Position += speed;
        waitFireTimer -= TimeProvider.DeltaTime;
        if(waitFireTimer <= 0f)
        {
            waitFireTimer = modelView.FireTimer;
             Fire();
        }
    }

    public override void FixedUpdate()
    {
        Vector3 pos = CameraHelper.OnOffScreen(modelView.Position, new Vector3(-1f, 0f, 0f));
        modelView.Position = pos;
    }

    public override void OnCollision()
    {
        GameLogic.Instance.UpdateScore(modelView.Score);
        modelView.Destroy();
    }

    private void Fire()
    {
        if (GameLogic.Instance.ShipInstance == null)
        {
            return;
        }
        Vector3 playerPos = GameLogic.Instance.ShipInstance.transform.position;
        Vector3 dir = modelView.Position - playerPos ;
        Quaternion rotation = Quaternion.LookRotation(dir, Vector3.forward);
        // making it so it rotates only in Z
        rotation.x = 0f;
        rotation.y = 0f;
        FactoryProvider<BulletFactory>.GetFactory().CreateBullet(modelView, EntityType.Enemy, rotation);
    }
}
