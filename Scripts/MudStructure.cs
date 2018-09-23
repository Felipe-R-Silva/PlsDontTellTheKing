using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudStructure : MonoBehaviour {
    public GameObject mudPrefab;
    GameObject []mudPieces;
    public Transform[] children;
    public float[] picktime;
    public float timer;
    public float RespawnDelay=10;
    private float maxTime=100;
    // Use this for initialization
    void Start () {
        //default RespawnDelay
            children = this.gameObject.GetComponentsInChildren<Transform>(true);
            //-1 because GetComponentsInChildren gets the parent in the position 0 so you need to ignore that.
            mudPieces = new GameObject[children.Length-1];
            picktime = new float[children.Length-1];
            //populates the mud array and the time array
            for (int p = 1; p < children.Length; p++)
            {
            
                mudPieces[p-1] = children[p].gameObject;
                picktime[p-1] = -9999;
              //  print(mudPieces[p - 1].name);
        }

        }
	
	// Update is called once per frame
	void Update () {
        for(int i=0;i< picktime.Length;i++)
        {
            if (picktime[i] != -9999)
            {
                float p = picktime[i] + RespawnDelay;
                //print("picktime[i] + RespawnDelay is " + (picktime[i] + RespawnDelay) + "/ maxTime is" + maxTime + " / RespawnDelay is" + RespawnDelay);
                if ((p < maxTime) && (timer >= p))
                {
                    mudPieces[i].SetActive(true);
                    picktime[i] = -9999;
                }
                else
                if (p > maxTime && ((timer >= p - maxTime)&& (timer <= p - maxTime+2)))
                {
                    mudPieces[i].gameObject.SetActive(true);
                    picktime[i] = -9999;
                }
                
            }
        }

        if (timer > maxTime)
        {
            timer = 0;

        }
        timer += Time.deltaTime;

      
        

    }
}
