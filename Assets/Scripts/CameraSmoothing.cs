﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothing : MonoBehaviour
{
    public Transform player;
    public float smoothing = 1f;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
        transform.position = newPosition;
    }
}
