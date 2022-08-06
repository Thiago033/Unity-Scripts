using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform player;
    private GameObject player;

    private string PLAYER_TAG = "Player";
    private string BULLET_TAG = "Bullet";

    private Rigidbody2D myBody;
    private Vector2 movement;
    public float moveSpeed = 5f;
    
    GameHudController displayPoints;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(PLAYER_TAG);
        myBody = this.GetComponent<Rigidbody2D>();
        displayPoints = GameObject.FindObjectOfType<GameHudController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;

        Vector3 direction = player.transform.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        myBody.rotation = angle;

        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate(){
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction){
        myBody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag(BULLET_TAG))
        { 
            Destroy(gameObject);
            displayPoints.DisplayPoints();
        }
    }
}
