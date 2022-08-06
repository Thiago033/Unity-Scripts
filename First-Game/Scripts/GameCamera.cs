using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{

    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if player is dead, return
        if (!player) return;

        tempPos = transform.position;

        tempPos.x = player.position.x;
        tempPos.y = player.position.y;

        //min/max X
        if (tempPos.x < minX){
            tempPos.x = minX;
        }
        if (tempPos.x > maxX){
            tempPos.x = maxX;
        }

        //min/max Y
        if (tempPos.y < minY){
            tempPos.y = minY;
        }

        if (tempPos.y > maxY){
            tempPos.y = maxY;
        }

        transform.position = tempPos;
    }
}