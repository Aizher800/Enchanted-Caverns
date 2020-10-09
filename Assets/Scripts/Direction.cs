using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{

    public enum Dir
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public static Vector2 DirToVec2(Dir dir)
    {
        Vector2 retval = Vector2.right;
        switch (dir)
        {
            case Direction.Dir.UP:
            retval = Vector2.up;
            break;
            case Direction.Dir.DOWN:
            retval = Vector2.down;
            break;
            case Direction.Dir.LEFT:
            retval = Vector2.left;
            break;
            case Direction.Dir.RIGHT:
            retval = Vector2.right;
            break;

        }
        return retval;
    }
}
