using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    CharacterController _controller; 

    public Transform _camera; 
    public float _mouseSensitivity = 10f;
    public float _speed = 5f; 
    public float _cameraVerticalRotation = 0f; 

    void Awake()
    {
        _controller = GetComponentInChildren<CharacterController>();
    }

    void Update()
    {
        Movement ();

    }
    void Movement()
    {
        float inputX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime; 
        float inputY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime; 
        
        //Movimiento hacia arriba y abajo
        _cameraVerticalRotation -= inputY; 
        _cameraVerticalRotation = Mathf.Clamp(_cameraVerticalRotation, -90f, 90f);
        _camera.localEulerAngles = Vector3.right * _cameraVerticalRotation; 

        //Movimiento hacia los lados 
        transform.Rotate(Vector3.up * inputX);
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * y; 
        _controller.Move(move.normalized * _speed * Time.deltaTime);
    }
}