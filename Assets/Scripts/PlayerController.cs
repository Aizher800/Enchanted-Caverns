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
    private Vector2 lastPos;

    private Vector2 faceDir = new Vector2();

    public float projectileSpeed = 0.5f;
    public GameObject Ball;

    void Update()
    {

        if (Input.touchCount > 0)

        {

            touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    firstPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    lastPos = touch.position;
                    if (firstPos == lastPos)
                        SummonBall();
                    break;
            }

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
            bool has_moved = false;

            if (Mathf.Abs(result.y) > deadZone)
            {
                y_update += distMoved * (result.y / Mathf.Abs(result.y));
                has_moved = true;
            }

            if (Mathf.Abs(result.x) > deadZone)
            {
                x_update += distMoved * (result.x / Mathf.Abs(result.x));
                has_moved = true;
            }
            if (has_moved)
            {
                faceDir.x = x_update;
                faceDir.y = y_update;
            }
            lastPos = transform.position;
            transform.Translate(new Vector2(x_update, y_update));

        }
        else
        {

            stillTouched = false;

        }
    }
    void SummonBall()
    {
        var ball = Instantiate(Ball, transform.position, Quaternion.identity);
        ball.GetComponent<Ball>().direction = lastPos;
        ball.GetComponent<Rigidbody2D>().AddForce(faceDir * projectileSpeed);
    }
}