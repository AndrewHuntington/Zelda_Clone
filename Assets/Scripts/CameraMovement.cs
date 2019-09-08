using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // NOTE: This whole system will probably be replaced with Cinemachine at a later point.
    public Transform target;
    public float smoothing;

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

            // Lerp = finds distance between it and a target, 
            // and moves a percentage of that distance (towards the taget) each frame
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
