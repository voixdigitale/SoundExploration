using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.UI.Image;

public class AmbulanceMove : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _speed = 30f;

    // Update is called once per frame
    void Update()
    {
        var targetRotation = transform.rotation;
        transform.RotateAround(_center.position, Vector3.up * -1, _speed * Time.deltaTime);
        transform.rotation = targetRotation;
        transform.eulerAngles = new Vector3(0, targetRotation.y + _speed * Time.deltaTime, 0);
        transform.LookAt(_center.position);
        transform.Rotate(new Vector3(0, 90, 0));
    }
}
