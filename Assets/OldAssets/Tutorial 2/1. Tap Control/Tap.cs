using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Tap : MobileControls
{
    void Update()
    {
        if (isDesktop)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnTap(Input.mousePosition);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                  Vector3 touchposition = Camera.main.ScreenToWorldPoint(touch.position);
                  touchposition.z = 0.0f;
                  OnTap((Vector2) touchposition);  
                }   
            }
        }
    }
}

