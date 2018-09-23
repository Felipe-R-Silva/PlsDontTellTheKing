using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openUpgrade : MonoBehaviour {

    GameObject UIcontroler;
    void Start()
    {
        UIcontroler = GameObject.FindGameObjectWithTag("UIControlers");
    }
    public void CallOpenWindow(int ID)
    {
        UIcontroler.GetComponent<UIfunctions>().ChangeUpgrades(ID);
        UIcontroler.GetComponent<UIfunctions>().activateUpgradeWindow();
        UIcontroler.GetComponent<UIfunctions>().UpgradeMe = this.transform.root.gameObject;
    }
    public void CallOpenCraftWindow(string IDString)
    {
        UIcontroler.GetComponent<UIfunctions>().activateCraftWindow(IDString);
    }

}
