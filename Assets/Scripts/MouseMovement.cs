using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    static float mouseSpeed = 100f;
    float xRotation = 0f;
    float yRotation = 0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")* mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* mouseSpeed * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, 0f, 0f);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation,yRotation,0f);
    }
}
