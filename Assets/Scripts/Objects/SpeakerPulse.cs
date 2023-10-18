using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerPulse : MonoBehaviour
{
    [SerializeField] private float _pulseSize = 1.15f;
    [SerializeField] private float _returnSpeed = 1f;
    [SerializeField] private float _bpmSpeed = 1f;

    private Vector3 _startSize;

    private void Start() {
       _startSize = transform.localScale;
    //    StartCoroutine(SpeakerBeat());
    }

    private void Update() {
        transform.localScale = Vector3.Lerp(transform.localScale, _startSize, _returnSpeed * Time.deltaTime);
    }

    public void Pulse() {
        transform.localScale = _startSize * _pulseSize;
    }

    private IEnumerator SpeakerBeat() {
        while (true) { 
            yield return new WaitForSeconds(_bpmSpeed);
            Pulse();
        }
    }
}
