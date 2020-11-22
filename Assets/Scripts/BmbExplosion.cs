using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BmbExplosion : MonoBehaviour
{
    public float bmbLife;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, bmbLife);
    }
    public void Explosion()
    {
        int i; // cambiar esto por una expresion para que se destruya la bomba y se pongan fuegos y luego desaparezcan
    }
}
