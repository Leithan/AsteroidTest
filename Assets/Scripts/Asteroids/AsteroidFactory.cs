using UnityEngine;

public class AsteroidFactory  : GenericFactory
{
    public void CreateAsteroid(GameObject prefab, Vector3 position)
    {
        Create<IAsteroidModelView, AsteroidController>(prefab, position);
    }
}