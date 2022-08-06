using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D myBody;

    [SerializeField]
    private float bulletForce;

    private string ENEMY_TAG = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        bulletForce = 20;

        mainCam = Camera.main;
        myBody = GetComponent<Rigidbody2D>();

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;

        myBody.velocity = new Vector2(direction.x, direction.y).normalized * bulletForce;


        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }
}