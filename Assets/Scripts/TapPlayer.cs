using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapPlayer : MonoBehaviour
{
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        MobileControls.OnTap += Jump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void Jump(Vector2 tappos)
    {
        if (rb2d != null)
        {
            rb2d.velocity += Vector2.up * 3.0f;
        }
    }
}
