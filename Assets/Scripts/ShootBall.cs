using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    private Vector2 firstPos;
    private Vector2 lastPos;
    public Touch touch;

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
        }
    }

    void SummonBall()
    {
        Instantiate(Ball, transform.position, Quaternion.identity);
    }
}
