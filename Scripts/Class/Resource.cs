using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Resource {
    [SerializeField]
    string name;
    [SerializeField]
    int ID;
    [SerializeField]
    private int amount;
    [SerializeField]
    private bool active;

    public Resource(int newID,string newname)
    {
        name = newname;
        ID = newID;
        active = false;
        amount = 0;
    }

    public string getname()
    {
        return name;
    }
    public int getamount()
    {
        return amount;
    }
    public void setamount(int value)
    {
       amount= value;
    }
    public void Addamount(int value)
    {
        amount += value;
    }
    public void Subamount(int value)
    {
        amount -= value;
    }
    public int getID()
    {
        return ID;
    }
    public void activateResource(GameObject Objtoactivate)
    {
        active = true;
        Objtoactivate.SetActive(true);
    }
    public void activateResource()
    {
        active = true;
    }
    public bool isactive()
    {
        return active;
    }
    public void Debug()
    {
        MonoBehaviour.print("My name is "+ name +".My ID is "+ID+"and I am "+active+" active");
    }

}
