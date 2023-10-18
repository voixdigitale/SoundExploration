using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DoorSwitch : MonoBehaviour, IUsable {

    [SerializeField] Transform doorPivot;
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private float _doorAnimDuration = 1f;
    [SerializeField] private float _doorAnimTime = 0f;
    [SerializeField] private DoorState _doorState;

    [SerializeField] private float _closedDoorCutoff = 500f;
    [SerializeField] private float _openDoorCutoff = 5000f;

    private Vector3 doorAngle;
    private float openDoorRotation = -90f;

    private void Awake() {
        _doorState = DoorState.CLOSED;
    }

    private void Start() {
        doorAngle = doorPivot.eulerAngles;
    }

    private void Update() {
        if (_doorState == DoorState.OPENING) {
            doorAngle = new Vector3(
                0f,
                Mathf.LerpAngle(doorAngle.y, openDoorRotation, _doorAnimTime),
                0f
            );
            _audioMixer.SetFloat("LowpassSimple", Mathf.Lerp(_closedDoorCutoff, _openDoorCutoff, _doorAnimTime * (_openDoorCutoff - _closedDoorCutoff) / Mathf.Abs(openDoorRotation)));
            _doorAnimTime += Time.deltaTime * _doorAnimDuration;
            if (_doorAnimTime >= _doorAnimDuration) {
                _doorState = DoorState.OPEN;
                _doorAnimTime = 0f;
            }
        } else if (_doorState == DoorState.CLOSING) {
            doorAngle = new Vector3(
                0f,
                Mathf.LerpAngle(doorAngle.y, 0f, _doorAnimTime),
                0f
            );
            _audioMixer.SetFloat("LowpassSimple", Mathf.Lerp(_openDoorCutoff, _closedDoorCutoff, _doorAnimTime * (_openDoorCutoff - _closedDoorCutoff) / Mathf.Abs(openDoorRotation)));
            _doorAnimTime += Time.deltaTime * _doorAnimDuration;
            if (_doorAnimTime >= _doorAnimDuration) {
                _doorState = DoorState.CLOSED;
                _doorAnimTime = 0f;
            }
        }

        doorPivot.eulerAngles = doorAngle;
    }

    public void Use() {
        if (_doorState == DoorState.CLOSED) {
            _doorState = DoorState.OPENING;
        } else if (_doorState == DoorState.OPEN) {
            _doorState = DoorState.CLOSING;
        }
    }

    private enum DoorState {
        CLOSED,
        OPENING,
        OPEN,
        CLOSING
    }
}
