using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class requiredItems :MonoBehaviour {
    public GameObject UIcontroler;
    [SerializeField]
    public Need_Have[] itemlist;
    [SerializeField]
    public int valuecreatedPerClick;
    [SerializeField]
    public Text UiTxtCraftedItem;
    [SerializeField]
    public int itemID;
    [SerializeField]
    bool IcanCraft;

    void OnEnable(){
        IcanCraft = false;
        IcanCraft =refreshBigpictureData();
    }

    public bool refreshBigpictureData()
    {
        bool allBoolAreTrue=true;
        for (int x = 0; x < itemlist.Length; x++)
        {
            //get amount in inventorry
            itemlist[x].sethave(Bullet.PlayerMaster.Instance.Inventory[itemlist[x].IteminMasterID].getamount());
            //assigning inventorry data to window(have)
            if (itemlist[x].gethave() < 10)
            {
                itemlist[x].havetex.text = "0" + itemlist[x].gethave().ToString();
            }
            else { itemlist[x].havetex.text = itemlist[x].gethave().ToString(); }
            //assigning inventorry data to window(need)
            if (itemlist[x].need < 10)
            {
                itemlist[x].needtex.text = "0" + itemlist[x].need.ToString();
            }
            else { itemlist[x].needtex.text = itemlist[x].need.ToString(); }
            //Check if you have the minimum and assign the bolean for it and hilight with colors
            if (itemlist[x].gethave() >= itemlist[x].need)
            {
                itemlist[x].haveImage.color = Color.green;
                itemlist[x].canICreate = true;
            }
            else {
                itemlist[x].haveImage.color = Color.red;
                allBoolAreTrue = false; 
            }
        }
        return allBoolAreTrue;

    }

    public void craft() {
        if (IcanCraft)
        {
            //seting internal values
            int setamount = Bullet.PlayerMaster.Instance.Inventory[itemID].getamount() + valuecreatedPerClick;
            Bullet.PlayerMaster.Instance.Inventory[itemID].setamount(setamount);
            //seting in-game values
            UiTxtCraftedItem.text= setamount.ToString();
            if (!UiTxtCraftedItem.transform.parent.gameObject.activeSelf)
            {
                //activate in master and activate in UI
                Bullet.PlayerMaster.Instance.Inventory[itemID].activateResource(UiTxtCraftedItem.transform.parent.gameObject);

            }
            //remove all used Items
            for (int x = 0; x < itemlist.Length; x++)
            {
                //remove from master
                int amountInMaster = Bullet.PlayerMaster.Instance.Inventory[itemlist[x].IteminMasterID].getamount();
                Bullet.PlayerMaster.Instance.Inventory[itemlist[x].IteminMasterID].setamount(amountInMaster - itemlist[x].need);
                //remove from interface
                itemlist[x].UiTxtConsumedItem.text = Bullet.PlayerMaster.Instance.Inventory[itemlist[x].IteminMasterID].getamount().ToString();
                //refresh data for crafting window
                IcanCraft = refreshBigpictureData();
            }

            }
    }

}
