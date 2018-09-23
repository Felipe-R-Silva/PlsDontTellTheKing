using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class folow : MonoBehaviour
{

    public bool ishead=false;

   Vector3 relativeRotation;
    Quaternion targetRotation;
    public Transform target;
    public Transform head;

    public float speed = 0.1F;

    bool rotating =false;
    float rotationTime; //whne rotationtime=1 you finish rotation 

    float timeLeft;
    public float turnbodydelay;

    // Use this for initialization
    //public GameObject target;
    void Start()
    {
        if (!ishead)
        {
            turnbodydelay=head.GetComponent<folow>().turnbodydelay;
            timeLeft = turnbodydelay;
            speed = head.GetComponent<folow>().speed;
        }
        else
            timeLeft = turnbodydelay;
        //Realwordlvector3 = transform.TransformDirection(new Vector3(0, 0, 1));

        StartCoroutine(follow());
    }

    // Update is called once per frame
 
    IEnumerator follow()
    {
        //target = Camera.main.gameObject;
        while (true)
        {
            timeLeft -= Time.deltaTime;
            if (!ishead)
            {
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
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }else

            //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .03f);
             transform.Translate(Vector3.back * speed* Time.deltaTime, target.transform);
            //transform.rotation = Quaternion.LookRotation(transform.position - target.transform.position);
            yield return new WaitForSeconds(0);

        }
    }
}
