using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class townManager : MonoBehaviour {


    public GameObject UiCanvasOBJ;
    public int curentmoney;
    public Text moneyText;
    public Image moneyBar;
    public GameObject Fill_Money;
    public int curentworker;
    public Text workersText;
    public GameObject Fill_Workers;
    public Image workersBar;
    // Use this for initialization
    void Start () {
        UiCanvasOBJ.GetComponent<UIfunctionsTown>().AddWorker(Bullet.PlayerMaster.Instance.Workers);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
