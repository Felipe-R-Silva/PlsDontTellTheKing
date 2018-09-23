using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestroyObject : MonoBehaviour {
    public GameObject spriteAdd;
    GameObject UIcontroler;
    
    public int UiTxtID;
    public bool ElementIsUpgrade;
    public int UpgradeID;

    public int valueAdd=1;

    void Start()
    {
        UIcontroler = GameObject.FindGameObjectWithTag("UIControlers");
    }
    void OnDestroy()
    {
            UIcontroler.GetComponent<UIfunctions>().AddUIElement(valueAdd, UiTxtID, ElementIsUpgrade, UpgradeID);
 
        Instantiate(spriteAdd, transform.position + new Vector3(0, 0.4f, 0), transform.rotation);

    }
}