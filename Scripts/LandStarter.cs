using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LandStarter : MonoBehaviour
{
    //private List<GameObject> floorEfectMasters;
    //We Get ths data from Ground_MAP
    [SerializeField]
    GameObject playerSceneData;
    [SerializeField]
    private Land MasterInfo;
    [SerializeField]
    public Vector2 WhereAmI;
    [SerializeField]
    public int ID;
    [SerializeField]
    public bool isUpgrade;
    [SerializeField]
    public int UpgradeID;
    [SerializeField]
    public string LandName;
    [SerializeField]
    public GameObject CreationPrefab;
    [SerializeField]
    bool drawtime = false;

    // Use this for initialization
    public Land getMaster()
    {
        return MasterInfo;
    }
    public void setMaster(Land newMaster)
    {
        MasterInfo = newMaster;
    }
    void Start()
    {
        playerSceneData = GameObject.Find("PlayerInformation");
        if (isUpgrade)
        {
            MasterInfo = new Land(this.transform.position, CreationPrefab, WhereAmI.x, WhereAmI.y, ID, LandName, UpgradeID);
        }
        else MasterInfo = new Land(this.transform.position, CreationPrefab, WhereAmI.x, WhereAmI.y,ID, LandName);
        //MasterInfo.setType(this.tag);
        var children = this.gameObject.GetComponentsInChildren<Transform>();
        //print("I am here");
        MasterInfo.getCoordinates();
        ID = (int)MasterInfo.getID();
        foreach (var child in children)
        {
            if (child.name == "MudStructure" || child.name == "WheatStructure" ||child.name == "WaterStructure")
            {
                //floorEfectMasters.Add(child.gameObject);
                /*
                floorEfectMaster = new Mud(child.gameObject);
                Debug.Log(floorEfectMaster.getMudArr()[0]);
                Debug.Log(floorEfectMaster.getMudArr()[1]);
                Debug.Log(floorEfectMaster.getMudArr()[2]);
                Debug.Log(floorEfectMaster.getMudArr()[3]);
                Debug.Log(floorEfectMaster.getMudArr()[4]);
                Debug.Log(floorEfectMaster.getMudArr()[5]);
                Debug.Log(floorEfectMaster.getMudArr()[6]);
                //floorEfectMaster.printMudNames();
                */
                //print(child.name);
            }

                if (child.name == "Dimension_Pin_Slice")
            {
                var Pins = child.gameObject.GetComponentsInChildren<Transform>();
                foreach (var pin in Pins)
                {
                    //Debug.Log(pin.name);
                    if (pin.name == "Pin_Stone")
                    {
                        MasterInfo.SetCenterPin(pin.gameObject);

                    }
                    if (pin.name == "Red_Pin_Slice")
                    {
                        MasterInfo.SetRPin(pin.gameObject);

                    }
                    if (pin.name == "Green_Pin_Slice")
                    {
                        MasterInfo.SetGPin(pin.gameObject);

                    }
                    if (pin.name == "Yellow_Pin_Slice")
                    {
                        MasterInfo.SetYPin(pin.gameObject);

                    }
                    if (pin.name == "Blue_Pin_Slice")
                    {
                        MasterInfo.SetBPin(pin.gameObject);

                    }
                }

            }
        }

        drawtime = true;
        //Debug.Log("Drawtime is "+drawtime);
        //print(MasterInfo.GetYPin());
        //print(MasterInfo.GetRPin());
        //print(MasterInfo.GetGPin());
        //print(MasterInfo.GetBPin());

        //safeTheDataOnSave-FarmList

        //AddFarmTOThe Saveslot
        if (playerSceneData != null)
        {
            
            playerSceneData.GetComponent<PlayerInventory>().AddFarm(getMaster());
        }
        else { Debug.Log("Can Not Find PlayerData playerSceneData=null"); }
    }
    void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        if (drawtime == true)
        {
            Gizmos.color = Color.blue;
            for (int i = 0; i < 8; i++)
            {
                Gizmos.DrawLine(MasterInfo.GetRPin().transform.position + new Vector3(0, i, 0), MasterInfo.GetGPin().transform.position + new Vector3(0, i, 0));
                Gizmos.DrawLine(MasterInfo.GetGPin().transform.position + new Vector3(0, i, 0), MasterInfo.GetYPin().transform.position + new Vector3(0, i, 0));
                Gizmos.DrawLine(MasterInfo.GetYPin().transform.position + new Vector3(0,i, 0), MasterInfo.GetBPin().transform.position + new Vector3(0, i, 0));
                Gizmos.DrawLine(MasterInfo.GetBPin().transform.position + new Vector3(0, i, 0), MasterInfo.GetRPin().transform.position + new Vector3(0, i, 0));
            }
        }

        // Update is called once per frame
    }
}
