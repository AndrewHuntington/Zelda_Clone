using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // NOTE: This whole system will probably be replaced with Cinemachine at a later point.
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            // keeping the Z value as the camera's own keeps the camera pulled back and able to film the scene 
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            // Lerp = finds distance between it and a target, 
            // and moves a percentage of that distance (towards the taget) each frame
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
