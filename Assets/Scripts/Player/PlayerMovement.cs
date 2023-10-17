using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _walkBobSpeed = 14f;
    [SerializeField] private float _walkBobAmount = .05f;
    [SerializeField] private float _breatheBobSpeed = 14f;
    [SerializeField] private float _breatheBobAmount = .05f;
    [SerializeField] private float _toggleHeadBobSpeed = 3f;

    CharacterController _characterController;
    AudioSource _stepsAudio;
    private float defaultYPos = 0;
    private float timer = 0;


    private void Awake() {
        _characterController = GetComponent<CharacterController>();
        _stepsAudio = GetComponent<AudioSource>();
        defaultYPos = _camera.localPosition.y;
    }

    private void Update() {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;
        Vector3 move = direction * _speed * Time.deltaTime;

        _characterController.Move(move);
        HandleHeadBob();
        HandleStepsAudio();
    }

    private void HandleStepsAudio() {
        float speed = new Vector3(_characterController.velocity.x, 0f, _characterController.velocity.z).magnitude;

        if (speed > _toggleHeadBobSpeed) {
            _stepsAudio.enabled = true;
        } else {
            _stepsAudio.enabled = false;
        }
    }

    private void HandleHeadBob() {
        float speed = new Vector3(_characterController.velocity.x, 0f, _characterController.velocity.z).magnitude;

        timer += Time.deltaTime * (speed < _toggleHeadBobSpeed ? _breatheBobSpeed : _walkBobSpeed);
        _camera.localPosition = new Vector3(
            _camera.localPosition.x,
            defaultYPos + Mathf.Sin(timer) * (speed < _toggleHeadBobSpeed ? _breatheBobAmount : _walkBobAmount),
            _camera.localPosition.z);
    }
}
