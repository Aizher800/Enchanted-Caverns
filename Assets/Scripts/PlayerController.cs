using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Touch touch;
    public float distMoved = 1f;
    public float deadZone = 0.5f;
    private Vector2 firstPos = new Vector2();
    private bool stillTouched = false;
    public float turnPerSec = 0.5f;
    private float actionBucket = 0f;
    private Vector2 lastPos;

    void Update()
    {
        if (true || actionBucket <= 0f)
        {


            if (Input.touchCount > 0)

            {
                touch = Input.GetTouch(0);
                if (!stillTouched)
                {
                    firstPos = touch.position;
                    stillTouched = true;
                    return;
                }
                var result = touch.position - firstPos;

                result.Normalize();
                float x_update = 0f, y_update = 0f;

                if (Mathf.Abs(result.y) > deadZone)
                {
                    y_update += distMoved * (result.y / Mathf.Abs(result.y));
                }
                if (Mathf.Abs(result.x) > deadZone)
                {
                    x_update += distMoved * (result.x / Mathf.Abs(result.x));
                }

                lastPos = transform.position;
                transform.Translate(new Vector2(x_update, y_update));
                //transform.position = new Vector2(transform.position.x + x_update, transform.position.y + y_update);
                actionBucket = turnPerSec;

            }
            else
            {
                stillTouched = false;

            }
        }
        else
        {
            actionBucket -= Time.deltaTime;
            
        }
    }
}