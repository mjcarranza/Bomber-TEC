using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int enemyHealth;
    public int enemyValue;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Explosion")
        {
            Destroy(gameObject);
        }
    }
}
