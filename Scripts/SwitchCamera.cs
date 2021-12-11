using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private Camera normalCam;
    [SerializeField] private Camera UICam;

    private void Awake()
    {
        UICam = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
