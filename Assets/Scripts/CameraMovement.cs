using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        transform.position = target.position;
    }
}
