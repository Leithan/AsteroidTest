using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    public static void CreateExplosion(Vector3 position)
    {
        var prefab = ResourceProvider.Instance.GetResource(ResourceTypes.Explosion);
        var instance = Instantiate(prefab);
        instance.transform.position = position;
    }
}