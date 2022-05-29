using UnityEngine;

public class TimeProvider : MonoBehaviour
{
    public static float DeltaTime = 0f;
    public static bool Pause;

    void Update()
    {
        DeltaTime = Pause ? 0f : Time.deltaTime;
    }
}