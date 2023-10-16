using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadBob : MonoBehaviour
{
    [SerializeField] Transform _camera;
    [SerializeField] Transform _eyeLevel;
    
    [SerializeField] private float _frequency = 10f;
    [SerializeField] private float _amplitude = .015f;
    [SerializeField] private float _stabilization = 15f;

    private float _toggleSpeed = 3.0f;
    private Vector3 _startPos;
    private CharacterController _characterController;

    private void Awake() {
        _characterController = GetComponent<CharacterController>();
        _startPos = _camera.localPosition;
    }

    private void Update() {
        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusStabilizer());
    }

    private Vector3 FocusStabilizer() {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _eyeLevel.localPosition.y, transform.position.z);
        pos += _eyeLevel.forward * _stabilization;
        return pos;
    }

    private void ResetPosition() {
        if (_camera.localPosition == _startPos) return;

        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }

    private void CheckMotion() {
        float speed = new Vector3(_characterController.velocity.x, 0f, _characterController.velocity.z).magnitude;
        if (speed < _toggleSpeed) { return; }
        //if (!_characterController.isGrounded) { return; } //Si je mets le saut

        PlayMotion(HeadBobMovement(_frequency, _amplitude));
    }

    private void PlayMotion(Vector3 motion) {
        _camera.localPosition += motion;
    }

    private Vector3 HeadBobMovement(float frequency, float amplitude) {
        Vector3 pos = Vector3.zero;
        pos.x = Mathf.Sin(Time.time * frequency) * amplitude;
        pos.y = Mathf.Cos(Time.time * frequency / 2) * amplitude * 2;
        return pos;
    }
}
