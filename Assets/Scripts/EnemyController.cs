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
    //Rigidbody2D rb2d;

    public float stunTimer = 2f;
    private float stunCountdown = 0f;
    public bool isStunned;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < aggroRange && !isStunned)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
            AnimationDirection();
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        if (isStunned)
        {
            stunCountdown -= Time.deltaTime;
            if (stunCountdown < 0f)
            {
                isStunned = false;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }


    private void AnimationDirection()
    {
        var direction = player.position - transform.position;

        direction.Normalize();
        //bool isUp = Mathf.Abs(direction.y) > Mathf.Abs(direction.x);

        /*if (isUp)
        {
            if (direction.y > 0f)
            {
                animator.SetBool("isRunning", true);
                //animator.Play("Base Layer.Up");
            }
            else
            {
                animator.SetBool("isRunning", true);
                //animator.Play("Base Layer.Down");
            }
        }
        else
        {
            if (direction.x > 0f)
            {
                animator.SetBool("isRunning", true);
                //animator.Play("Base Layer.Right");
            }
            else
            {
                animator.SetBool("isRunning", true);
                //animator.Play("Base Layer.Left");
            }
        }*/
        animator.SetBool("isRunning", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            stunCountdown = stunTimer;
            isStunned = true;

        }
    }
}
