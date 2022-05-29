using UnityEngine;

public interface IMoveable
{
    Vector3 Position { get; set; }

    Quaternion Rotation { get; set; }

    float Speed { get; set; }

    EntityType EntityType { get; set; }

    void Destroy();
}