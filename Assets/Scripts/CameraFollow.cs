using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target object to follow (usually the player).

    void LateUpdate()
    {
        if (target != null)
        {
            // Get the target's position.
            Vector3 targetPosition = target.position;
            Vector3 cameraPosition = new Vector3(targetPosition.x, 2.5f, -10);
            // Set the camera's position to the calculated position.
            transform.position = cameraPosition;
        }
    }
}
