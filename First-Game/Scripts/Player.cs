using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float movementX;
    private float movementY;
    private string RFLIGHT_ANIMATION = "RFlight";
    private string LFLIGHT_ANIMATION = "LFlight";

    private Rigidbody2D playerBody;
    private string ENEMY_TAG = "Enemy";

    private Animator anim;
    private SpriteRenderer spriteRender;
    private Camera mainCam;
    private Vector3 mousePos;
    
    private void Awake(){
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();

        mainCam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotationWithMouse();
        PlayerMovement();
        AnimatePlayer();
    }

    void PlayerMovement(){
        movementX = Input.GetAxisRaw("Horizontal");
        movementY = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(movementX, movementY, 0f) * Time.deltaTime * moveSpeed;
    }

    void AnimatePlayer(){

        /*
        // LEFT  -1 
        //STOPPED 0 
        //RIGHT   1

        //Goind to the right side
        if (movementX > 0 )
        {
            anim.SetBool(RFLIGHT_ANIMATION, true);
        }
        //Going to the left side
        else if(movementX < 0){
            anim.SetBool(LFLIGHT_ANIMATION, true);
        }
        //Stopped
        else{
            anim.SetBool(LFLIGHT_ANIMATION, false);
            anim.SetBool(RFLIGHT_ANIMATION, false);
        }
        */

        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            GameMenuController.isGameOver = true;
            
            Destroy(gameObject);
        }
    }

    void PlayerRotationWithMouse(){
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ-90);
    }
}