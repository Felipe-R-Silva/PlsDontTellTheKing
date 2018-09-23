using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Colectable")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.name == "Apple")
        {
            Destroy(col.gameObject);
        }


    }
}
