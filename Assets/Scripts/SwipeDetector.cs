using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MobileControls
{
    public float minSwipeDistance = 25.0f; //pixels

    Vector2 starttouch;
    Vector2 endtouch;




    void Update()
    {
        if (isDesktop)
        {
            float v = Input.GetAxisRaw("Vertical");
            float h = Input.GetAxisRaw("Horizontal");

            Vector2 spos = Vector2.zero;
            Vector2 epos = new Vector2(h, v) * minSwipeDistance;
            //Debug.Log(epos);
            CheckSwipe(spos, epos);
        }
        else
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    starttouch = touch.position;
                    endtouch = touch.position;
                }

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
                {
                        endtouch = touch.position;
                        CheckSwipe(starttouch, endtouch);
                }
            }
        }
    }

    void CheckSwipe(Vector2 s_pos, Vector2 e_pos)
    {
        float vdist = Mathf.Abs(e_pos.y - s_pos.y);
        float hdist = Mathf.Abs(e_pos.x - s_pos.x);
        bool isVerticalSwipe = (vdist > hdist);
        bool swipeDistMet = ((vdist >= minSwipeDistance) || (hdist >= minSwipeDistance));

        if (swipeDistMet)
        {
            SwipeData sdata = new SwipeData();

            if (isVerticalSwipe)
            {
                if (e_pos.y > s_pos.y)
                {
                    //Debug.Log("Up");
                    sdata.dir = Direction.Dir.UP;
                }
                else
                {
                    //Debug.Log("Down");
                    sdata.dir = Direction.Dir.DOWN;
                }
            }
            else
            {
                if (e_pos.x > s_pos.x)
                {
                    //Debug.Log("Right");
                    sdata.dir = Direction.Dir.RIGHT;
                }
                else
                {
                    //Debug.Log("Left");
                    sdata.dir = Direction.Dir.LEFT;                
                }         
            }

            OnSwipe(sdata);
        }
    }
}
