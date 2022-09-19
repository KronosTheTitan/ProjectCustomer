using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeOutMessage : MonoBehaviour
{
    
    private float startTime;
    
    [SerializeField] float fadeDelayTime;

    [SerializeField] private float fadeTime;

    [SerializeField] private TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime + fadeDelayTime)
        {
            float t = Mathf.InverseLerp(startTime + fadeDelayTime, startTime + fadeDelayTime + fadeTime, Time.time);
            if(t>=1) Destroy(gameObject);
            Debug.Log(t);
            text.color = new Color(text.material.color.r,text.material.color.b,text.material.color.g, Mathf.Lerp(1, 0, t));
        }
    }
}