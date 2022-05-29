using UnityEngine;

public static class CameraHelper
{
    // Return object back to the camera bounds
    //This gives the illusion of wrap around borders
    public static Vector3 OnOffScreen(Vector3 position, Vector3 forward)
    {
        Vector3 cameraPosition = Camera.main.WorldToViewportPoint(position);
        if (cameraPosition.x > 1 || cameraPosition.x < 0)
        {
            position.x = -position.x + forward.x * 0.1f;
        }

        if (cameraPosition.y > 1 || cameraPosition.y < 0)
        {
            position.y = -position.y + +forward.y * 0.1f;
        }

        return position;
    }
}