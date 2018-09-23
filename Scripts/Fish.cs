using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {
    public Transform[] waypoints;
    public float rate = 20;
    private int currentWaypoint = 0;

    void Start()
    {
        MoveToWaypoint();
    }

    void OnDrawGizmos()
    {
        iTween.DrawLine(waypoints, Color.yellow);
    }

    void MoveToWaypoint()
    {
        //Time = Distance / Rate:
        float travelTime = Vector3.Distance(transform.position, waypoints[currentWaypoint].position) / rate;

        //iTween:
        iTween.MoveTo(gameObject, iTween.Hash("position", waypoints[currentWaypoint], "time", travelTime, "easetype", "Linear", "oncomplete", "MoveToWaypoint", "Looktarget", waypoints[currentWaypoint].position, "looktime", 1.5));

        //Move to next waypoint:
        currentWaypoint++;
        if (currentWaypoint > waypoints.Length - 2)
        {
            currentWaypoint = 0;
        }
    }
}
