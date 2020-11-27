using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BmbFire : MonoBehaviour
{
    public float fire;
    public GameObject ExplosionPref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, fire);
    }
}
