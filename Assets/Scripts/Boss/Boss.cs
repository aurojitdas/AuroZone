using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform player;
    Animator animator;
    Rigidbody2D rb;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //animator.SetFloat("Velocity",1);
        //Debug.Log(Mathf.Abs(rb.velocity.x)+"Hello");
    }

    public void lookAtPlayer()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1.8f, 1.8f, 1f);
        }
        else if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(1.8f, 1.8f, 1f);
        }
    }
}
