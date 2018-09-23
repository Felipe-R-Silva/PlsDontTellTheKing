using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodScript : MonoBehaviour {
    public GameObject food;
    //public GameObject apple;
    private List<GameObject> apples;

    //Here you add 3 BadGuys to the List
    // Use this for initialization
    void Start () {
        apples = new List<GameObject>();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            apples.Add(Instantiate(food, transform.position, transform.rotation));
            //apple =Instantiate(food, transform.position, transform.rotation);
            apples[apples.Count - 1].name= "Apple";
            //apple.name = "Apple";
        }
        //debug
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            //print("you have " + apples.Count + " elements in your list");
            for (int x = 0; x < apples.Count; x++)
            {
                if (apples[x] == null && apples.Count!=0)
                {
                    apples.RemoveAt(x);
                   // print("null element removed");
                }
            }
            print(apples.Count);
            for(int x=0;x< apples.Count;x++)
            {
                if (apples[x] == null)
                {
                    apples.RemoveAt(x);
                }
                //print(apples[x]);
            }
        }
        */
    }
     
}
