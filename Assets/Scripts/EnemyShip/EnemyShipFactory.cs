using UnityEngine;

public class EnemyShipFactory : GenericFactory
{
    public void CreateEnemy()
    {
        var prefabList = ResourceProvider.Instance.GetAllResources(ResourceTypes.EnemyShip);
        var prefab = prefabList[Random.Range(0, prefabList.Count)];
        Create<IEnemyShipModelView, EnemyShipController>(prefab, Vector3.zero);
    }
}
