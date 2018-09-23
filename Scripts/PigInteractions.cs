using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigInteractions : MonoBehaviour {

    
    public GameObject hearth;
    GameObject root;
    Land master;
    GameObject target;
    public string targetName;
    public Vector3 relativeposition;
    public float distanceEat;
    public float distanceEatHight;
    Vector3 Realwordlvector3;
    Vector3 InverseRealwordlvector3;
    public float timer;




    // Use this for initialization
    void Start () {
            target = GameObject.Find(targetName);
        relativeposition = target.transform.position - transform.position;

        root = transform.root.gameObject;
        master = root.GetComponent<LandStarter>().getMaster();
    }
	
	// Update is called once per frame
	void Update () {
        if (timer >= 100)
        {
            timer = 0;
        }
        timer += Time.deltaTime;
        //return transform.TransformDirection(direction);
        Realwordlvector3 =transform.TransformDirection(new Vector3(0, 0, 1));
        //print("Apple: " + target.transform.position + "Pig: " + transform.position);
        if (target != null)
        {
            relativeposition =  transform.position - target.transform.position;
            InverseRealwordlvector3 = transform.InverseTransformDirection(new Vector3(Realwordlvector3.x, 0, Realwordlvector3.z));
            //check x axis
            if (target.transform.position.x > master.GetRPin().transform.position.x  && target.transform.position.x < master.GetGPin().transform.position.x ) {
                if (target.transform.position.z > master.GetRPin().transform.position.z  && target.transform.position.z < master.GetBPin().transform.position.z )
                {

                    //move pig
                    transform.Translate(InverseRealwordlvector3 * Time.deltaTime);
                }
            }
            if ((Mathf.Abs(relativeposition.x) < distanceEat) && (Mathf.Abs(relativeposition.z) < distanceEat && (Mathf.Abs(relativeposition.y) < distanceEatHight)))
            {
                
                Destroy(target);
                Instantiate(hearth, transform.position, transform.rotation);
                target = null;
            }

        }
        if (target == null)
        {
            target = GameObject.Find(targetName);
            relativeposition = target.transform.position - transform.position;
        }

    }
}
