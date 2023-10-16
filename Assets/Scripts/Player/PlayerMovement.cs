using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    CharacterController _characterController;


    private void Awake() {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;
        Vector3 move = direction * _speed * Time.deltaTime;

        _characterController.Move(move);
    }
}
