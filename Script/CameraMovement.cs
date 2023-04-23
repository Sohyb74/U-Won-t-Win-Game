using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerPosition;
    public Vector3 offset;
    [Range(1,10)]
    public float smoothFactor;
    private void FixedUpdate(){
        follow();
    }
    void follow(){
        Vector3 targetPosition = playerPosition.position+offset;
        Vector3 smoothedTransition = Vector3.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothedTransition;
    }
}
