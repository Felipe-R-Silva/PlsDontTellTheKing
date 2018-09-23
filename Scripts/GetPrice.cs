using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPrice : MonoBehaviour {
    public GameObject UIInfo;
    public int arrayID;
    void Start() {
        
    this.GetComponent<Text>().text = Bullet.FarmMaster.Instance.BlocksInGame[arrayID].getBuildableBlocksPrice().ToString()+" coins";

    }
}
