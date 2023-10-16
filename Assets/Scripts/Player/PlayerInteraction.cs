using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Image _crosshair;

    [SerializeField] private float _maxDistance = 3f;
    [SerializeField] private IUsable _target;

    private void Update() {
        FindTarget();
        UseTarget();
        ChangeCrosshairState();
    }

    private void FindTarget() {
        RaycastHit hit;
        
        if (Physics.Raycast(_camera.position, _camera.forward, out hit, _maxDistance) && hit.transform.gameObject.GetComponent<IUsable>() != null) {
            _target = hit.transform.gameObject.GetComponent<IUsable>();
        } else {
            _target = null;
        }
    }

    private void UseTarget() {

    }

    private void ChangeCrosshairState() {
        if (_target != null) {
            _crosshair.color = Color.blue;
        } else {
            _crosshair.color = Color.white;
        }
    }
}
