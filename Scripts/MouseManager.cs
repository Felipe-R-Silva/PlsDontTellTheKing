using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {
    public GameObject UIfunctionScrip;
    public GameObject playerInventory;
void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...



            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                int HitID;

                if (hit.transform.root.gameObject.GetComponent<LandStarter>())
                {
                    HitID = hit.transform.root.gameObject.GetComponent<LandStarter>().ID;
                    switch (HitID)
                    {
                        case 7:
                            IfHitLand(hit, "orepuzzle",2);
                            break;
                        case 6:
                            IfHitLand(hit, "fishpuzzle",1);
                            break;
                        case 5:
                            IfHitLand(hit, "brickpuzzle",1); 
                            break;
                        case 4:
                            IfHitLand(hit, "rockpuzzle", 2);
                            break;
                        case 3:
                            IfHitLand(hit, "Bushpuzzle", 1);
                            IfHitLand(hit, "SmallTreepuzzle", 1);
                            IfHitLand(hit, "PigTreepuzzle", 1); 
                            IfHitLand(hit, "PineTreepuzzle", 1);


                            break;
                        case 2:
                                IfHitLand(hit, "Wheatpuzzle", 1);
                            break;
                        case 1:
                            IfHitLand(hit, "waterpuzzle", 1);
                            IfHitLand(hit, "fishpuzzle", 1);
                            break;
                        case 0:
                            IfHitLand(hit, "mudpuzzle",1);
                            break;
                        default:
                            print(hit.transform.name+"Incorrect Hit.(puzzle)");
                            break;
                    }

                }
                // the object identified by hit.transform was clicked
                // do whatever you want
                //colectable itens in the game
                if (hit.transform.tag == "Colectable")
                {
                    Destroy(hit.transform.gameObject);

                    //if (hit.transform.name == "colec-" + "mud" + "(Clone)")
                    //{
                    //    Destroy(hit.transform.gameObject);
                    //}
                    //if (hit.transform.name == "colec-" + "wheat" + "(Clone)")
                    //{
                    //    Destroy(hit.transform.gameObject);
                    //}
                    //if (hit.transform.name == "colec-" + "bucket" + "(Clone)")
                    //{
                    //    Destroy(hit.transform.gameObject);
                    //}
                    //if (hit.transform.name == "colec-" + "log" + "(Clone)")
                    //{
                    //    Destroy(hit.transform.gameObject);
                    //}
                }
            }
        }
    }
    public bool IfHitLand( RaycastHit hit, string name, int workersneeded)
    {
        bool manageToFindTarget=false;
        for (int i = 0; i < hit.transform.parent.GetComponent<MudStructure>().children.Length; i++)
            {
            

            if (hit.transform.gameObject.name == name + "(" + i + ")" || hit.transform.gameObject.name == name)
                {
                //Consme  worker
                if (UIfunctionScrip.GetComponent<UIfunctions>().RemoveWorker(workersneeded, hit.transform.gameObject))
                {
                    hit.transform.parent.GetComponent<MudStructure>().picktime[i] = hit.transform.parent.GetComponent<MudStructure>().timer;
                    Instantiate(hit.transform.parent.GetComponent<MudStructure>().mudPrefab, hit.transform.position + new Vector3(0, 0.4f, 0), hit.transform.rotation);
                    hit.transform.gameObject.SetActive(false);
                    manageToFindTarget = true;
                    break;
                }
                }
            }

        return manageToFindTarget;
    }
}
