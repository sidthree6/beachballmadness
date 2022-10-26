using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    public GameObject enemy;

    private float StartY;
    private float StartX;

    private GamePlayScript gameplay;

	// Use this for initialization
	void Start () {

        StartY = -3.25f;
        StartX = 12.0f;

        gameplay = GameObject.FindGameObjectWithTag("gameplay").GetComponent<GamePlayScript>();

        StartCoroutine(SpawningEnemy());
        
	}

    IEnumerator SpawningEnemy()
    {
        while(true)
        {
            int waitingTime = Random.Range(3, 6);

            yield return new WaitForSeconds(waitingTime);

            if(gameplay.CurrentGameState == GameState.Playing)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy,new Vector3(StartX,StartY,0),Quaternion.identity);
    }

}
