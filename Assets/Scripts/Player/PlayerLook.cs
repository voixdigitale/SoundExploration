using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private Vector2 _mouseSensitivity = new Vector2(1000f, 1000f);
    [SerializeField] private Vector2 _padSensitivity;
    [SerializeField] private Vector2 _mouseYLimit;

    private float _horizontal;
    private float _vertical;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        GetInput();

       _vertical = Mathf.Clamp(_vertical, _mouseYLimit.x, _mouseYLimit.y);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _horizontal, transform.eulerAngles.z);
        _cameraTransform.eulerAngles = new Vector3(_vertical, _cameraTransform.eulerAngles.y, _cameraTransform.eulerAngles.z);

    }

    private void GetInput() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        mouseX *= _mouseSensitivity.x;
        mouseY *= _mouseSensitivity.y;

        float gamepadX = Input.GetAxis("Horizontal");
        float gamepadY = Input.GetAxis("Vertical");
        gamepadX = gamepadX * _mouseSensitivity.x * Time.deltaTime;
        gamepadY = gamepadY * _mouseSensitivity.y * Time.deltaTime;

        _horizontal += mouseX + gamepadX;
        _vertical += mouseY + gamepadY;
    }
}
