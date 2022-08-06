using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{   
    public GameObject[] PowerUps;
    private GameObject player;

    public bool powerUpSpawned = false;

    private string PLAYER_TAG = "Player";

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG);
        StartCoroutine (spawnPowerUp());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator spawnPowerUp(){
        yield return new WaitForSeconds(5);
        
        while (!powerUpSpawned)
        {
            Vector3 position = new Vector3(Random.Range(-20f, 20f), Random.Range(-12f, 12f), 0);
            if ((position - player.transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(PowerUps[Random.Range(0,2)], position, Quaternion.identity);
                powerUpSpawned = true;
            }
        }
        StartCoroutine(spawnPowerUp());
    } 
}