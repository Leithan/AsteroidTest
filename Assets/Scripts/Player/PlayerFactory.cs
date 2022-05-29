using UnityEngine;

public class PlayerFactory : GenericFactory
{
    public GameObject CreatePlayerShip()
    {
        var shipPrefab = ResourceProvider.Instance.GetResource(ResourceTypes.PlayerShip);
        return Create<IPlayerModelView, PlayerController>(shipPrefab, Vector3.zero);
    }
}