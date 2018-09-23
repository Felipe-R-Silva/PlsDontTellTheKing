using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : MonoBehaviour {

    public float timeDeleat;
    // Use this for initialization

    // Update is called once per frame
    void Update () {
        timeDeleat -= Time.deltaTime;
        if (timeDeleat <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
