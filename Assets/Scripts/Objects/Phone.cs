using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Phone : MonoBehaviour, IUsable {

    [SerializeField] private AudioMixer _audioMixer;

    private void Awake() {
        
    }

    private void Start() {
        
    }

    public void Use() {
        GetComponent<AudioSource>().Play();
    }
}

