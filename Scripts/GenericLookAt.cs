using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericLookAt : MonoBehaviour {

    public GameObject target;
    void Start()
    {
        target = Camera.main.gameObject;
        StartCoroutine(Spin());
    }

    IEnumerator Spin()
    {
        target = Camera.main.gameObject;
        while (true)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
            yield return new WaitForSeconds(0);

        }


    }
     
}
