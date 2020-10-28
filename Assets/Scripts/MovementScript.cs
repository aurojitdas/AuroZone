﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Transform startPosition;
    public Transform pos1, pos2;
    public float speed;
    private Vector3 nextPos;
   
    
    void Start()
    {
        nextPos = startPosition.position;

    }

    
    void Update()
    {
        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
            
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
       

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }

   
}   
   
