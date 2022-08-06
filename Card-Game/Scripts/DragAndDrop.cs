using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DragAndDrop : NetworkBehaviour
{
   
    [HideInInspector]
    public bool isOverPlayerDropZone = false;

    public GameObject dropZone;

    private GameObject playerDropZone;
    //private GameObject player2DropZone;

    private Vector2 startPosition;

    private GameObject canvas;
    private GameObject startParent;
    
    public PlayerManager playerManager;

    private bool isDragging = false;
    private bool isDraggable = true;

    void Start(){
        canvas = GameObject.Find("Main Canvas");
        dropZone = GameObject.Find("Drop Zone");

        if (!hasAuthority)
        {
            isDraggable = false;
        }
    }

    void Update(){
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(canvas.transform, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        isOverPlayerDropZone = true;
        playerDropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision){
        isOverPlayerDropZone = false;
        playerDropZone = null;
    }


    public void BeginDrag(){
        if (!isDraggable) return;

        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag(){
        if (!isDraggable) return;

        isDragging = false;

        if (isOverPlayerDropZone)
        {
            transform.SetParent(playerDropZone.transform, false);
            isDraggable = false;
            NetworkIdentity networkIdentity = NetworkClient.connection.identity;
            playerManager = networkIdentity.GetComponent<PlayerManager>();
            playerManager.PlayCard(gameObject);
        }
        else
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}