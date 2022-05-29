using UnityEngine;

public class BulletFactory : GenericFactory
{
    public void CreateBullet(IMoveable caster, EntityType sourceType)
    {
        CreateBullet(caster, sourceType, caster.Rotation);
    }

    public void CreateBullet(IMoveable caster, EntityType sourceType, Quaternion rotation)
    {
        ResourceTypes resourceType;
        switch(sourceType)
        {
            case EntityType.Enemy:
                resourceType = ResourceTypes.EnemyBullet;
                break;
            default:
                resourceType = ResourceTypes.Bullet;
                break;
        }

        var prefab = ResourceProvider.Instance.GetResource(resourceType);
        var go = Create<IBulletModelView, BulletController>(prefab, caster.Position);
        var modelView = go.GetComponent<IBulletModelView>();
        modelView.Rotation = rotation;
        modelView.EntityType = sourceType;
        // adding the caster speed so it goes even further away, otherwise it looks weird
        modelView.Speed += caster.Speed; 
    }
} 
