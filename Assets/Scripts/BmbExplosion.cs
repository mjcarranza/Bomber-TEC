using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BmbExplosion : MonoBehaviour
{
    public float bmbLife;
    public float fireLife;
    public bool active = false;
    public GameObject ExplosionPrefav;

    // Update is called once per frame
    void Update()
    {
        bmbLife += Time.deltaTime;
        fireLife += Time.deltaTime;
        if (bmbLife >= 2 && bmbLife < 3)
        {
            Destroy(gameObject, bmbLife - 1);
            //Instantiate(ExplosionPrefav, transform.position, transform.rotation);
            active = true;
        }
        if (active == true)
        {
            if(fireLife >= 3 && fireLife < 4)
            {
                AutoExplode();
            }
        }
    }
    void AutoExplode()
    {
        Instantiate(ExplosionPrefav, transform.position, transform.rotation);
        active = false;
    }
}
