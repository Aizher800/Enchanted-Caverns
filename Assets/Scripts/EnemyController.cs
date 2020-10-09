using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Transform player;
    public float aggroRange;
    public float moveSpeed;

    public Animator animator;
    Vector2 move;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < aggroRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
            AnimationDirection();
        }
        else
        {
            animator.Play("Base Layer.IdleDown");
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, aggroRange);
    }

    private void AnimationDirection()
    {
        var direction = player.position - transform.position;
 
        direction.Normalize();
        bool isUp = Mathf.Abs(direction.y) > Mathf.Abs(direction.x);

        if (isUp)
        { 
            if (direction.y > 0f)
            {
                animator.Play("Base Layer.Up");
            }
            else
            {
                animator.Play("Base Layer.Down");
            }
        }
        else 
        {
            if (direction.x > 0f)
            {
                animator.Play("Base Layer.Right");
            }
            else
            {
                animator.Play("Base Layer.Left");
            }
        }
    }
}
