using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ResourceItem
{
    public ResourceTypes ResourceType;
    public GameObject Resource;
}

[CreateAssetMenu(menuName = "SOs/ResourcesSO")]
public class ResourcesSO : ScriptableObject
{
    public List<ResourceItem> ResourceList = new List<ResourceItem>();
}
