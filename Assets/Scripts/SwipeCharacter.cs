using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCharacter : MonoBehaviour
{
    enum LastDirection
    {
        left,
        right,
        up,
        down,
        none
    }

    public GameObject characterPrefab;
    private Animator animator;
    private LastDirection lastDirection = LastDirection.none;

    void Start()
    {
       MobileControls.OnSwipe += OnSwipe;
       if (characterPrefab != null)
       {
           GameObject GO = Instantiate(characterPrefab, transform.position, Quaternion.identity);
           GO.transform.SetParent(transform);
           animator = GO.GetComponent<Animator>();
       }
    }

    void Update()
    {
        if (Input.touchCount == 0)
        {
            onIdle();
        }
    }
    void OnSwipe (SwipeData sd)
    {
       if (animator != null)
        {
            switch (sd.dir)
            {
                case Direction.Dir.UP:
                    if (lastDirection != LastDirection.up)
                        animator.Play("Base Layer.Up");
                    lastDirection = LastDirection.up;
                break;

                case Direction.Dir.DOWN:
                    if (lastDirection != LastDirection.down)
                        animator.Play("Base Layer.Down");
                    lastDirection = LastDirection.down;
                    break;

                case Direction.Dir.LEFT:
                    if (lastDirection != LastDirection.left)
                        animator.Play("Base Layer.Left");
                    lastDirection = LastDirection.left;
                    break;

                case Direction.Dir.RIGHT:
                    if (lastDirection != LastDirection.right)
                        animator.Play("Base Layer.Right");
                    lastDirection = LastDirection.right;
                    break;
                default:
                break;
            }
        }
    }
    void onIdle()
    {
        switch (lastDirection)
        {
            case LastDirection.up:
                animator.Play("Base Layer.IdleUp");
                lastDirection = LastDirection.none;
                break;
            case LastDirection.down:
                animator.Play("Base Layer.IdleDown");
                lastDirection = LastDirection.none;
                break;
            case LastDirection.right:
                animator.Play("Base Layer.IdleRight");
                lastDirection = LastDirection.none;
                break;
            case LastDirection.left:
                animator.Play("Base Layer.IdleLeft");
                lastDirection = LastDirection.none;
                break;
            default:
                break;
        }
    }
}

