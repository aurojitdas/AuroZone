using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    private PlayerMovement gameplayer;
    private int coins;
    public Text coinText;
    public Text livesText;
    public int lives;
    void Start()
    {
        gameplayer = FindObjectOfType<PlayerMovement>();
        lives = 3;
        coinText.text = "Coins: "+coins;
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respawnPlayer()
    {
        StartCoroutine("respawnCoroutine");
       
    }

    public void addCoins(int coinValue)
    {
        coins = coins + coinValue;
        coinText.text = "Coins: " + coins;
    }

    public IEnumerator respawnCoroutine()
    {
        gameplayer.gameObject.SetActive(false);
        if (lives>0)
        {
            yield return new WaitForSeconds(respawnDelay);
            gameplayer.transform.position = gameplayer.respawnPoint;
            gameplayer.gameObject.SetActive(true);
            lives--;
            livesText.text = "Lives: " + lives;

        }
        else
        {
            livesText.text = "Game Over";


        }
       
    }
}
