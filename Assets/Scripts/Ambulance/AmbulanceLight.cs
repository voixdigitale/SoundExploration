using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceLight : MonoBehaviour
{
    [SerializeField] Material _lightOnMaterial;
    [SerializeField] Material _lightOffMaterial;
    [SerializeField] float _delay;

    bool AreLightsOn = false;

    private void Start() {
        StartCoroutine(TriggerLights());
    }

    private IEnumerator TriggerLights() {
        while (true) {
            yield return new WaitForSeconds(_delay);

            if (AreLightsOn) {
                GetComponent<Renderer>().material = _lightOffMaterial;
                AreLightsOn = false;
            } else {
                GetComponent<Renderer>().material = _lightOnMaterial;
                AreLightsOn = true;
            }
        }
    }

}
