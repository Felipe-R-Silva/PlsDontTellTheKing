using UnityEngine;
using System.Collections;

public class rotatebody : MonoBehaviour
{
    Vector3 relativeRotation;
    Quaternion targetRotation;
    public string targetName;
    public Transform target;
    
    public float speed = 0.1F;

    bool rotating =false;
    float rotationTime; //whne rotationtime=1 you finish rotation 

    float timeLeft;
    public float turnbodydelay;

    

    void Start()
    {
        target=GameObject.Find(targetName).transform;
        timeLeft = turnbodydelay;
    }

    void Update()
    {
        if (target!=null) {
            //PigInteractions.Cs
            //print("Apple: " + target.position + "Pig: " + transform.position);
            //transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (target == null)
        {
            target = GameObject.Find(targetName).transform;
        }
        timeLeft -= Time.deltaTime;
      //  if (Input.GetKeyDown(KeyCode.Space))
          if (timeLeft < 0)
          {
            timeLeft = turnbodydelay;
            relativeRotation = target.position - transform.position;
            relativeRotation.y = 0;
            targetRotation = Quaternion.LookRotation(relativeRotation);
            rotating = true;
            rotationTime = 0;
        }
        if (rotating)
        {
            rotationTime += Time.deltaTime * speed;
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationTime);
        }
        if (rotationTime > 1)
        {
            rotating = false;
        }
    }

}