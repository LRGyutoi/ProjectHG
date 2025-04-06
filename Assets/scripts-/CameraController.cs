using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform player;
    public Canvas canvas;
    public GameObject tablet;

    float _xRotation;
    float _yRotation;

    const float YMin = -90f;
    const float YMax = 90f;
    void Start()
    {
        Vector3 currentEulerAngles = transform.rotation.eulerAngles;
        currentEulerAngles.z = 0f;
        transform.rotation = Quaternion.Euler(currentEulerAngles);
    }
    
    void Update()
    {
        if(tablet.activeSelf == true)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
            _yRotation += mouseX;
            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, YMin, YMax);
        
            transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
        
            player.rotation = Quaternion.Euler(0, _yRotation, 0);
        }
    }
}
