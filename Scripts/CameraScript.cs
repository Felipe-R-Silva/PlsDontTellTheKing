using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject target;
    public Vector3 distance;
    public Vector3 distanceChange;
    // Use this for initialization


    void Start()
    {
        distance = distanceChange;
    }

    // Update is called once per frame
    void dUpdate()
    {
        // transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);
        /*
        if (distance.x !=distanceChange.x)
        {
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, transform.position.x + distanceChange.x, 1.0f * Time.deltaTime),0,0);
        }else
        */
        distance = this.gameObject.transform.position - target.transform.position;
        target = GameObject.Find("MainStone");
        transform.LookAt(target.transform);

    }
}
