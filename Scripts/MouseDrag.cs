using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour {

    float distance = 11;
    public Vector3 velocity;
    Vector3 lastVelocity;
    public Vector3 aceleration;

    public Renderer rend;


    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    void OnMouseDrag()
    {
        //change color on click
        //rend.material.color -= Color.green * Time.deltaTime;
        
        //get game object of draged object
        //GameObject p;
        //p = rend.gameObject;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objectPosition;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

    }

    void update()
    {
        velocity = GetComponent<Rigidbody>().velocity;
        aceleration = (GetComponent<Rigidbody>().velocity - lastVelocity) / Time.fixedDeltaTime; ;
        lastVelocity = GetComponent<Rigidbody>().velocity;

    }

}
