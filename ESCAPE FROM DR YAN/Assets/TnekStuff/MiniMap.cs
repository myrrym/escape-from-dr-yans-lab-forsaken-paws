using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform FPSController;

    private void LateUpdate()
    {
        Vector3 newPosition = FPSController.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
