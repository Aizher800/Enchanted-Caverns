using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeData
{
    public Direction.Dir dir;
    /*
    could have extra data for:
    - length/velocity of swipe
    - position on the screen where the swipe occurred
    */
}


public class MobileControls : MonoBehaviour
{
    public delegate void PosDelegate(Vector2 pos);
    public delegate void SwipeDelegate(SwipeData swipe);
    public delegate void TouchArrayDelegate(Touch[] touches);
    

    public static PosDelegate OnTap;
    public static PosDelegate OnTilt;
    public static SwipeDelegate OnSwipe;
    public static TouchArrayDelegate OnMultiTouch;

    public bool isDesktop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
