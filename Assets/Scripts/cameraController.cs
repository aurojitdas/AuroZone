using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    
    public GameObject player;
    public Vector3 playerPosition;
    public float offset;
    public float offsetSmotthing;
    
    void Start()   
    {
       
    }
    void Update()
    {

        playerPosition = new Vector3(player.transform.position.x,transform.position.y,transform.position.z);

        if (player.transform.localScale.x>0)
        {
            //Adding this if statement to prevent camera moving beyond the starting point
            //Offset is added to player position bcz we r adding offset 2 the camera
            if (playerPosition.x < -6+ offset)
            {
                playerPosition = new Vector3(-6+offset, playerPosition.y, playerPosition.z);
            }
            else
            {
                playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
            }
        }
        else
        {
            if (playerPosition.x < -6+offset)
            {
                playerPosition = new Vector3(-6+ offset, playerPosition.y, playerPosition.z);
            }
            else
            {
                playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
            }
        }
       //Setting Camera Position
        transform.position = Vector3.Lerp(transform.position,playerPosition,offsetSmotthing * Time.deltaTime);

    }
}
