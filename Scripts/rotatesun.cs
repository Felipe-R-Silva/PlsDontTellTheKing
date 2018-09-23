using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatesun : MonoBehaviour {
    public GameObject clock;
    public int curentTime;
    int morningtime;//starts 0 in x
    int nighttime;//starts 180 in x

    public float desiredRotation;
    //6-20= 14h
    //20-6= 10h
    // Use this for initialization
    void Start () {
        morningtime = 6;
        nighttime = 20;

        }
	
	// Update is called once per frame
	void Update () {
        curentTime=clock.GetComponent<clock>().get_hours();

        print(transform.eulerAngles);
        if (curentTime <= nighttime && curentTime > morningtime)
        {
            desiredRotation = ((curentTime - morningtime) * (180 / 14)) * -1;
            transform.eulerAngles = new Vector3(desiredRotation, 0, 0);
        }
        else
        {
            if (curentTime > nighttime && curentTime <= 24)
            {
                desiredRotation = ((curentTime - nighttime) * (180 / 10) +180) * -1;
                transform.eulerAngles = new Vector3(desiredRotation, 0, 0);
            }
            else
            {
                desiredRotation = ((curentTime + (24 - nighttime)) * (180 / 10) +180) * -1;
                transform.eulerAngles = new Vector3(desiredRotation, 0, 0);
            }
        }

    }
}
