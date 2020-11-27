using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlyerControl : MonoBehaviour
{
    public float timer;
    bool firstBmb = true;
    public Transform bombSpawner;
    public GameObject bombPrefav;

    // Update is called once per frame
    void Update()
    {
        // Player`s movement
        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(-2f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("right"))
        {
            gameObject.transform.Translate(2f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("up"))
        {
            gameObject.transform.Translate(0, 2f * Time.deltaTime, 0);
        }
        if (Input.GetKey("down"))
        {
            gameObject.transform.Translate(0, -2f * Time.deltaTime, 0);
        }
        // player`s attack
        if (Input.GetKeyDown("space"))
        {
            if (firstBmb == true)
            {
                playerBmb();
                firstBmb = false;
            }
            else
            {
                if (timer >= 3)
                {
                    playerBmb();
                    timer = 0;
                }
            }
        }
        timer += Time.deltaTime;
        
    }
    public void playerBmb()
    {
        Instantiate(bombPrefav, bombSpawner.position, bombSpawner.rotation);
    }
}
