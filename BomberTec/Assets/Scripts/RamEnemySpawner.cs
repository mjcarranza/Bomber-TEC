using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamEnemySpawner : MonoBehaviour
{
    /*
     * Definition of variables
     */
    public Transform[] spawnPoints;
    public float[] usedPoints;
    public GameObject[] enemyPrefabs;
    int randEnemy;
    int randSpawnPoint;
    int counter;
    public bool enemyExist;
    public bool used;

    /*
     * Start is called before the first frame update
     */
    void Start()
    {
        /*
         * initializing values
         */
        usedPoints = new float[10];
        counter = 0;
        used = false;
    }

    /*
     * Update is called once per frame
     */
    void Update()
    {
        /*
         * If there isn`t any enemy in the game, this method draws it
         */
        if (enemyExist == false)
        {
            for (int i=0; i<enemyPrefabs.Length; i++)
            {
                randSpawnPoint = Random.Range(0, spawnPoints.Length);

                if(usedPoints.Length == 0)
                {
                    Instantiate(enemyPrefabs[i], spawnPoints[randSpawnPoint].position, transform.rotation);
                    usedPoints[counter] = randSpawnPoint;
                    counter += 1;
                }
                else
                {
                    /*
                     * Function call
                     */
                    IsIn();
                    if(used == false)
                    {
                        Instantiate(enemyPrefabs[i], spawnPoints[randSpawnPoint].position, transform.rotation);
                        usedPoints[counter] = randSpawnPoint;
                        counter += 1;
                    }
                    else if (used == true)
                    {
                        // se puede hacer cuatro condicionales para que el personaje no se dibuje fuera del laberinto
                        Instantiate(enemyPrefabs[i], spawnPoints[randSpawnPoint+1].position, transform.rotation);
                        usedPoints[counter] = randSpawnPoint;
                        counter += 1;
                        used = false;
                    }
                }
                
            }
            enemyExist = true;
        }
    }
    /*
     * If a spawn point is used the gae cannot use it again
     */ 
    public void IsIn()
    {
        for (int j=0; j<usedPoints.Length; j++)
        {
            if (randSpawnPoint == usedPoints[j])
            {
                used = true;
            }
            else
            {
                used = false;
            }
        }
    }
}
