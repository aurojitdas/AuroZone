using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;
    public float movementSpeed;
    private Rigidbody2D rgb2d;
    public float range;
    private float distance;




    // Start is called before the first frame update
    void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position,player.position);

        if (distance<range)
        {
            chasePlayer();
        }
        else 
        {
            stopChasingPlayer();
        }
        
        
    }

    

    private void chasePlayer()
    {
        
         if (transform.position.x < player.position.x)
        {
            rgb2d.velocity = new Vector2(movementSpeed, 0);
            transform.localScale = new Vector2(-3, 3);
        }
        else if (transform.position.x > player.position.x)
        {
            rgb2d.velocity = new Vector2(-movementSpeed, 0);
            transform.localScale = new Vector2(3, 3);
        } 
        
    }
    private void stopChasingPlayer()
    {
        rgb2d.velocity = new Vector2(0, 0);
    }
}
