using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {
    public int speed;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spin());
        transform.Rotate(Vector3.right * Random.Range(0,360));
        


    }

    IEnumerator Spin()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            
            transform.Rotate(Vector3.right * speed * Time.smoothDeltaTime);
        }
    }
}
