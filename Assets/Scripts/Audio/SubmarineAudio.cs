using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

// [RequireComponent(typeof(AudioSource),typeof(Submarine))]
public class SubmarineAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip lowFuelSound;
    [SerializeField] private Submarine submarine;

    private void Start()
    {
        // audioSource = GetComponent<AudioSource>();
        // submarine = GetComponent<Submarine>();
    }

    private void Update()
    {
        // float actualSpeedPercent = submarine.speedPercent >= 0 ? submarine.speedPercent : submarine.speedPercent * -1;
        // audioSource.volume = actualSpeedPercent;


        if (GameManager.Instance.isLowFuel)
        {
            audioSource.clip = lowFuelSound;
            audioSource.Play();
            Debug.Log("Audio");
        }
    }
    
    
}
