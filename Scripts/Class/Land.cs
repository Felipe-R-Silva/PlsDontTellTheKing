using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Land  {
    [SerializeField]
    string name;
    [SerializeField]
    Vector2 xyCoo;
    [SerializeField]
    Vector3 coordinate; //World coord
    [SerializeField]
    GameObject blockPref; // GameObject reference
    [SerializeField]
    private long ID=-1; //Object ID
    [SerializeField]
    bool IsUpgrade;//if house is a upgrade
    [SerializeField]
    int UpgradeID=-1;//Upgrade ID

    private GameObject bluePin;

    private GameObject redPin;

    private GameObject greenPin;

    private GameObject yellowPin;

    private GameObject CenterPin;
    // Use this for initialization

    public Land(Vector3 coo,GameObject Prefab , float x, float y,int newID,string newName)
    {
        xyCoo.x = x;
        xyCoo.y = y;
        coordinate = coo;
        blockPref = Prefab;
        ID = newID;
        name = newName;
    }
    public Land(Vector3 coo, GameObject Prefab, float x, float y, int newID, string newName,int newupgradeID)
    {
        xyCoo.x = x;
        xyCoo.y = y;
        coordinate = coo;
        blockPref = Prefab;
        ID = newID;
        name = newName;
        UpgradeID = newupgradeID;
        IsUpgrade = true;
    }
    public Land(Land otherLand)
    {
        xyCoo = otherLand.getXyCoo();
        coordinate = otherLand.getCoordinates();
        blockPref = otherLand.getPref();
        ID = otherLand.getID();
        bluePin = otherLand.GetBPin();
        redPin = otherLand.GetRPin();
        greenPin = otherLand.GetGPin();
        yellowPin = otherLand.GetYPin();
        CenterPin = otherLand.GetCenterPin();
        name = otherLand.getName();
        Debug.Log("New Created");
        Debug.Log("ID"+ID);
        Debug.Log("coordinate" + coordinate);

    }
    public void SetPins (GameObject cp, GameObject bp , GameObject rp , GameObject gp , GameObject yp)
    {
        CenterPin = cp;
        bluePin = bp;
        redPin = rp;
        greenPin = gp;
        yellowPin = yp;
        return;
    }
    //Set Pins
    public void SetBPin(GameObject bp)
    {
        bluePin = bp;
        return;
    }
    public void SetRPin(GameObject rp)
    {
        redPin = rp;
        return;
    }
     public void SetGPin (GameObject gp)
    {
        greenPin = gp;
        return;
    }
    public void SetYPin(GameObject yp)
    {
        yellowPin = yp;
        return;
    }
    public void SetCenterPin(GameObject cp)
    {
        CenterPin = cp;
        return;
    }

    //Get Pins
    public GameObject GetBPin()
    {
        return bluePin;
    }
    public GameObject GetRPin()
    {
        return redPin;
    }
    public GameObject GetGPin()
    {
        return greenPin;
    }
    public GameObject GetYPin()
    {
        return yellowPin;
    }
    public GameObject GetCenterPin()
    {
        return CenterPin;
    }

    //Get ID
    public long getID()
    {
        return ID;
    }
    //Get UpgradeID
    public int getUpgradeID()
    {
        return UpgradeID;
    }
    //Set UpgradeID
    public void setUpgradeID(int newUpgradeID)
    {
        UpgradeID= newUpgradeID;
        IsUpgrade = true;
    }
    public void setID(long newID)
    {
        ID = newID;
        if (newID == 0) {
            name = "PigBlock";
        }
        if (newID == 1)
        {
            name = "WaterBlock";
        }
        if (newID == 2)
        {
            name = "WheatBlock";
        }
        if (newID == 3)
        {
            name = "WoodBlock";
        }
    }
    //getxyCOo
    public Vector2 getXyCoo()
    {
        return xyCoo;
    }
    public string  getName()
    {
        return name;
    }
    //set name
    public void setName(string ty) {
        name = ty;
        return;
    }
    public Vector3 getCoordinates()
    {
        return coordinate;
    }
    public GameObject getPref()
    {
        return blockPref;
    }

}
