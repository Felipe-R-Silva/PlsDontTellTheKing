using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {
    public GameObject functionsUI;
    public Text moneyText;
    public PlayerItems myItems;
    public int money;
    public int worker;
    public int amount;
    [SerializeField]
    public List<Land> FarmData = new List<Land>();
    [SerializeField]
    public List<Resource> Inventory = new List<Resource>();

    // Use this for initialization
    void Start() {
        myItems = new PlayerItems(Bullet.PlayerMaster.Instance.Money);
        worker = Bullet.PlayerMaster.Instance.Workers;
        Inventory = Bullet.PlayerMaster.Instance.Inventory;
        UIfunctions UIfunct = functionsUI.GetComponent<UIfunctions>();
        for (int ID = 0; ID < Inventory.Count; ID++)
        {

            functionsUI.GetComponent<UIfunctions>().SetUIElement(Inventory[ID].getamount(), ID,Inventory[ID].isactive());
        }
        //money is a fill bar
        
        UIfunct.AddWorker(worker);
        UIfunct.AddMoney(myItems.Getmoney());
    }
    //Debug
    public void AddFarm(Land newFarm)
    {
        FarmData.Add(new Land(newFarm));
        Bullet.PlayerMaster.Instance.FarmDataSave.Add(new Land(newFarm));
    }
    public void ActivateItem(int ID)
    {
        //Debug.Log(functionsUI.GetComponent<UIfunctions>().UITxt[ID].transform.parent.gameObject.name);
       // Debug.Log("ID requested " + ID);
        //Inventory[ID].Debug();
        Inventory[ID].activateResource(functionsUI.GetComponent<UIfunctions>().UITxt[ID].transform.parent.gameObject);
        
        save();
    }
    public void save()
    {
        
        Bullet.PlayerMaster.Instance.Money = myItems.Getmoney();
        Bullet.PlayerMaster.Instance.Inventory = Inventory;
        Bullet.PlayerMaster.Instance.Workers = worker;
        Bullet.PlayerMaster.Instance.FarmDataSave = FarmData;
        
    }
    public void saveMoney()
    {

        Bullet.PlayerMaster.Instance.Money = myItems.Getmoney();

    }
    public void saveWorkers()
    {
        Bullet.PlayerMaster.Instance.Workers = worker;
    }




    /*
     * not working
     for (int x = 0; x < FarmData.Count; x++)
          {
              if (FarmData[x].getPref() == null)
              {
                  FarmData.RemoveAt(x);
                  Bullet.PlayerMaster.Instance.FarmDataSave.RemoveAt(x);
              }
          }
          print(Bullet.PlayerMaster.Instance.FarmDataSave.Count + "<-cloud | scene->" + FarmData.Count);


       */

}
