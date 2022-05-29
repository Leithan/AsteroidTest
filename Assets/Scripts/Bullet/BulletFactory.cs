using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : GenericFactory
{
    private List<BulletModelView> bulletPool = new List<BulletModelView>();
    private List<BulletModelView> enemyBulletPool = new List<BulletModelView>();

    public void CreateBullet(IMoveable caster, EntityType sourceType)
    {
        CreateBullet(caster, sourceType, caster.Rotation);
    }

    public void CreateBullet(IMoveable caster, EntityType sourceType, Quaternion rotation)
    {
        ResourceTypes resourceType;
        switch (sourceType)
        {
            case EntityType.Enemy:
                resourceType = ResourceTypes.EnemyBullet;
                break;
            default:
                resourceType = ResourceTypes.Bullet;
                break;
        }

        var poolObject = GetFreeBullet(resourceType);
        if (poolObject == null)
        {
            var prefab = ResourceProvider.Instance.GetResource(resourceType);
            var go = Create<IBulletModelView, BulletController>(prefab, caster.Position);
            poolObject = go.GetComponent<BulletModelView>();
            AddToPool(poolObject, resourceType);
        }
        else
        {
            poolObject.Dead = false;
            poolObject.Position = caster.Position;
            poolObject.gameObject.SetActive(true);
        }
        
        poolObject.Rotation = rotation;
        poolObject.EntityType = sourceType;
        // adding the caster speed so it goes even further away, otherwise it looks weird
        poolObject.ExtraSpeed = caster.Speed;
    }

    private void AddToPool(IBulletModelView modelView, ResourceTypes resourceType)
    {
        var list = resourceType == ResourceTypes.Bullet ? bulletPool : enemyBulletPool;
        list.Add(modelView as BulletModelView);
    }

    private BulletModelView GetFreeBullet(ResourceTypes resourceType)
    {
        var list = resourceType == ResourceTypes.Bullet ? bulletPool : enemyBulletPool;
        foreach (var modelView in list)
        {
            if (modelView.Dead)
            {
                return modelView;
            }
        }

        return null;
    }
}