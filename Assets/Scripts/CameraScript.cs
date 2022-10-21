using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject John;
    private Vector3 position;

    // Update is called once per frame
    void Update()
    {
        if (John != null)
        {
            position = transform.position;
            position.x = John.transform.position.x;
            transform.position = position;
        }
    }
}
