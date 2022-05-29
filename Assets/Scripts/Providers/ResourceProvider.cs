using System.Collections.Generic;
using UnityEngine;

public class ResourceProvider : MonoBehaviour
{
    public ResourcesSO ResourceSO;
    public static ResourceProvider Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetResource(ResourceTypes resourceType)
    {
        foreach (var item in ResourceSO.ResourceList)
        {
            if (item.ResourceType == resourceType)
            {
                return item.Resource;
            }
        }
        Debug.LogError($"No resource found with type {resourceType}");
        return null;
    }
    
    public List<GameObject> GetAllResources(ResourceTypes resourceType)
    {
        var result = new List<GameObject>();
        foreach (var item in ResourceSO.ResourceList)
        {
            if (item.ResourceType == resourceType)
            {
                result.Add(item.Resource);
            }
        }

        if (result.Count == 0)
        {
            Debug.LogError($"No resource found with type {resourceType}");
            return null;
        }

        return result;
    }
}