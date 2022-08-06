using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PowerUpSpawner powerUpSpawner;
    private GameObject player;
    private Shooting timeBetweenShooting;

    private string PLAYER_TAG = "Player";

    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG);
        powerUpSpawner = GameObject.FindObjectOfType<PowerUpSpawner>();
        timeBetweenShooting = GameObject.FindObjectOfType<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {  
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(PLAYER_TAG))
        {
            powerUpSpawner.powerUpSpawned = false;
            
            StartCoroutine(ActivatePowerUp());
        }
    }

    IEnumerator ActivatePowerUp(){

        timeBetweenShooting.timeBetweenFiring = 0.1f;
        Debug.Log(timeBetweenShooting.timeBetweenFiring);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;

        Debug.Log(duration);
        yield return new WaitForSeconds(duration);

        timeBetweenShooting.timeBetweenFiring = 0.3f;
        Debug.Log(timeBetweenShooting.timeBetweenFiring);

        Destroy(gameObject);
    }
}
