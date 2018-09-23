

//MAKE BETTER HANDLER FOR FIND APPLE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour {
    GameObject target;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(-Vector3.forward * Time.deltaTime);
        if (target == null)
        {
        
            target = GameObject.Find("Apple");
        }else
       // transform.LookAt(target.transform);
        transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
    }
}
