using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject[] obstList;
    public float ramX;
    public float ramY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obstList = GameObject.FindGameObjectsWithTag("DestObstacle");
        if (obstList.Length == 0)
        {
            obstacleSpawn();
        }
        //Debug.Log(obstList.Length);
    }
    public void obstacleSpawn()
    {
        for(int i=0; i<100; i++)
        {
            ramX = Random.Range(-8.5f, 9.5f);
            ramY = Random.Range(-3.5f, 2.5f);

            ramX = (ramX - (ramX % 1)) + 0.5f;
            ramY = (ramY - (ramY % 1)) + 0.5f;

            // if ramx o ramy estan en la posicion de un jugador, entonces se desplaza 2 unidades hacia la derecha, izquierda,
            // arriba o abajo siempre que se encuentre dentro de los limites del laberinto.

            // if ramx o ramy estan al lado de un jugador, entonces se desplaza 1 unidades hacia la derecha, izquierda,
            // arriba o abajo siempre que se encuentre dentro de los limites del laberinto.

            // else se dibuja el obstaculo en la posicion que se obtuvo con ramx y ramy

            Vector3 randomSpawn = new Vector3(ramX, ramY, 0);
            Instantiate(obstacle, randomSpawn, transform.rotation);
        }
    }

}
