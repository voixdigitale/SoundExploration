using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreathe : MonoBehaviour
{
    [SerializeField] private Transform eyeLevel;
    [SerializeField] private float _lissajousP = 2f;
    [SerializeField] private float _lissajousQ = 3f;
    [SerializeField] private float _breatheScale = 100f;
    [SerializeField] private float _breatheSpeed = 10f;

    [SerializeField] private float breatheTime;
    [SerializeField] private Vector3 breathePosition;
    
    private void Update() {
        Vector3 targetPosition = LissajousCurve(breatheTime, _lissajousP, _lissajousQ) / _breatheScale;
        breathePosition = Vector3.Lerp(breathePosition, targetPosition, Time.smoothDeltaTime * _breatheSpeed);
        breatheTime += Time.deltaTime;

        //Avoid Snapping
        if (breatheTime > 6.3f) {
            breatheTime = 0f;
        }

        eyeLevel.localPosition = breathePosition;

    }

    private Vector3 LissajousCurve(float Time, float p, float q) {
        return new Vector3(Mathf.Sin(Time), p * Mathf.Sin(q * Time + Mathf.PI));
    }
}
