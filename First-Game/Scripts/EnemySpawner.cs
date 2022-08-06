using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] monsterReference;

    private GameObject spawnedEnemy;

    private int randomIndex;
    private int randomPos;

    [SerializeField]
    private Transform TopLeft, TopRight, BottomLeft, BottomRight;


    // Start is called before the first frame update
    void Start() {
        
      StartCoroutine(SpawnEnemys());  

    }

    IEnumerator SpawnEnemys() {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));

            randomIndex = Random.Range(0, monsterReference.Length);
            randomPos = Random.Range(0,4);

            spawnedEnemy = Instantiate(monsterReference[randomIndex]);

            //Top Left
            if (randomPos == 0)
            {
                spawnedEnemy.transform.position = TopLeft.position;
            }
            //Top Right
            else if (randomPos == 1) {
                spawnedEnemy.transform.position = TopRight.position;
            }
            //Bottom Left
            else if (randomPos == 2){
                spawnedEnemy.transform.position = BottomLeft.position;
            }
            //Bottom Right
            else{
                spawnedEnemy.transform.position = BottomRight.position;
            }
        }
    }
}