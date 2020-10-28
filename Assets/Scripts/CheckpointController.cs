using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer chkPointRenderer;
    public bool chkPointReached;

    void Start()
    {
        chkPointRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            chkPointRenderer.sprite = greenFlag;
            chkPointReached = true;
        }
    }
}
