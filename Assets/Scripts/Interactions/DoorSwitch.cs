using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour, IUsable {

    [SerializeField] Transform doorPivot;
    
    private bool doorOpen = false;
    private Vector3 doorAngle;
    private float openDoorRotation = -90f;

    private void Start() {
        doorAngle = doorPivot.eulerAngles;
    }

    private void Update() {
        if (doorOpen) {
            doorAngle = new Vector3(
            0f,
            Mathf.LerpAngle(doorAngle.y, openDoorRotation, Time.deltaTime),
            0f);
        } else {
            doorAngle = new Vector3(
            0f,
            Mathf.LerpAngle(doorAngle.y, 0f, Time.deltaTime),
            0f);
        }

        doorPivot.eulerAngles = doorAngle;
    }

    public void Use() {
        if (!doorOpen) {
            doorOpen = true;
        } else {
            doorOpen = false;
        }
    }
}
