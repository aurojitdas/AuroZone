using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioClip coinAudio;
    private LevelManager levelManager;
    public int coinValue;
    
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Update()
    {  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            Destroy(gameObject);
            levelManager.addCoins(coinValue);
            AudioSource.PlayClipAtPoint(coinAudio, collision.transform.position);
           
        }
       
    }
}
