using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    void Start()
    {
        Camera.main.orthographicSize = 8; 
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Camera.main.orthographicSize = Camera.main.orthographicSize + 2 * Time.deltaTime;
            if (Camera.main.orthographicSize > 12)
            {
                Camera.main.orthographicSize = 12; 
            }
        }
        else
        {
            Camera.main.orthographicSize = 8; 
        }
    }
}
