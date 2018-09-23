using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIfunctions : MonoBehaviour {
    [Header("Select Cursor----------------------------")]
    public Texture2D[] cursorTextures;
    //[Header("Select Blocks----------------------------")]
    public GameObject Gamebuilder;
    [Tooltip("make sure to mach position in the array with functions")]
    public GameObject[] UiCardSelected;
    [Header("Upgrades----------------------------")]
    [Tooltip("make sure to mach position in the array with functions")]
    public GameObject[,] UiUpgrades;
    [Header("Future Class to solve mess--------------")]
    [SerializeField]
    public ButtonClass[] buildableButton;
    GameObject MoneyUI;

    //AddMoneyVariables
    [Header("Money---------------------------------")]
    public Image moneyBar;
    public Text moneyText;
    public GameObject PlayerInventoryGBJ;
    [Header("Workers-------------------------------")]
    public Image workersBar;
    public Text workersText;
    //public int money;
    int MAX_MoneyvalueSlider = 999;
    int MAX_WorkersvalueSlider = 100;

    [Header("UpgradesUI------------------------------")]
    public GameObject blackScrean;
    public GameObject UpgradeWindow;
    public GameObject Shop;
    [Header("CraftUI------------------------------")]
    public GameObject BigPictureParent;
    public GameObject ItemsCraftParent;
    public GameObject CraftWindow;
    [Header("CraftStations------------------------------")]
    //Dictionary<string, GameObject[]> CraftStations;
    [SerializeField]
    GameObject[] Windmill;
    [SerializeField]
    GameObject[] cookingPot;

    [Header("UpgradeBoxes----------------------------")]
    [Header("ID_0-------------ID_1-------------ID_2------------ID_3-------------ID_4")]
    public ArrayLayout data;

    //public ArrayLayout GameObjects;
    [Header("block requesting upgrade")]
    public GameObject UpgradeMe;
    public int upgradeMeID;
    public int upgradeMeSelecUp;

    //Auxiliar GameObjects
    [Header("WarningsUI----------------------------")]
    public GameObject NoMoney;
    public GameObject NoFarmer;
    [Header("UIInventory---------------------------")]
    public Text[] UITxt;

     void Start()
    {
        //Dictionary<string, GameObject[]> CraftStations = new Dictionary<string, GameObject[]>();
        
        //BuildableBlocks = Bullet.FarmMaster.Instance.BlocksInGame[ID].get_BuildableBlocks();;
        //SelectBlocks = Bullet.FarmMaster.Instance.BlocksInGame[ID].get_SelectBlocks();
        //BuildableBlocksPrice = Bullet.FarmMaster.Instance.BuildableBlocksPrice;
    }
    public void upgradeThis(GameObject Button)
    {
        
        int ID=Button.GetComponent<buttonID_Upgrade>().ID;
        int SelectedUpgrade = Button.GetComponent<buttonID_Upgrade>().Upgrade;
        GameObject newLand;
        //oldUpgradeME = UpgradeMe;
        
        newLand = Instantiate(Bullet.FarmMaster.Instance.BlocksInGame[ID].get_UpgradeBlock(SelectedUpgrade), UpgradeMe.transform.position, UpgradeMe.transform.rotation);
        //CreationPrefab
        newLand.GetComponent<LandStarter>().CreationPrefab = UpgradeMe.GetComponent<LandStarter>().getMaster().getPref();
        //WhereAmI
        newLand.GetComponent<LandStarter>().WhereAmI = UpgradeMe.GetComponent<LandStarter>().getMaster().getXyCoo();
        //ID
        newLand.GetComponent<LandStarter>().ID=(int)UpgradeMe.GetComponent<LandStarter>().getMaster().getID();
        //Name
        newLand.GetComponent<LandStarter>().name = UpgradeMe.GetComponent<LandStarter>().getMaster().getName()+"_"+ID;
        newLand.GetComponent<LandStarter>().isUpgrade = true;
        newLand.GetComponent<LandStarter>().UpgradeID = upgradeMeID;
        //CreationPrefab, WhereAmI.x, WhereAmI.y,ID, LandName
        Destroy(UpgradeMe);
        UpgradeMe = newLand;





    }
    public void ChangeUpgrades(int IDnum)
    {
        var parent = this.data.rows[0].ID[IDnum].transform.parent;
        //Debug.Log("Parent is : " + parent.name);
        Transform[] children = new Transform[parent.childCount];
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            children[i] = parent.transform.GetChild(i);
            //Debug.Log("children : " + i + " is-" + children[i].name);
            children[i].gameObject.SetActive(false);
        }

        data.rows[0].ID[IDnum].SetActive(true);
        data.rows[1].ID[IDnum].SetActive(true);
        data.rows[2].ID[IDnum].SetActive(true);
    }

    public void ChangeCursor(int ID)
    {
                Cursor.SetCursor(cursorTextures[ID], Vector2.zero, CursorMode.Auto);
    }
    public void ChangeSelection(int ID)
    {
        
        Gamebuilder.transform.GetComponent<Ground_Map>().SelectionBlock[1] = Bullet.FarmMaster.Instance.BlocksInGame[ID].get_SelectBlocks();
        Gamebuilder.transform.GetComponent<Ground_Map>().buyprice = Bullet.FarmMaster.Instance.BlocksInGame[ID].getBuildableBlocksPrice();
        Gamebuilder.transform.GetComponent<Ground_Map>().ConstructionBlock = Bullet.FarmMaster.Instance.BlocksInGame[ID].get_BuildableBlocks();
        Gamebuilder.transform.GetComponent<Ground_Map>().ConstructionBlockID = ID;
        Gamebuilder.transform.GetComponent<Ground_Map>().BlockName = Bullet.FarmMaster.Instance.BlocksInGame[ID].get_BuildableBlocksName();
        UiCardSelected[ID].SetActive(true);

    }

    public void AddMoney(int value)
    {
        
        //PlayerItems myItems = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems;
        if ((PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Getmoney()+ value < MAX_MoneyvalueSlider))
        {
            moneyBar.fillAmount += (float)value / MAX_MoneyvalueSlider;
            int moneyInCoins = Mathf.RoundToInt(moneyBar.fillAmount * MAX_MoneyvalueSlider);

            moneyText.text = moneyInCoins.ToString();
            PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Setmoney(moneyInCoins);
            PlayerInventoryGBJ.GetComponent<PlayerInventory>().money = moneyInCoins;

        }

        else { moneyBar.fillAmount = 1;
            PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Setmoney(MAX_MoneyvalueSlider);
        }
        //money = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Getmoney();


    }
    public void AddWorker(int value)
    {
        // UIfunct.workersText, UIfunct.workersBar, UIfunct.PlayerInventoryGBJ
        PlayerInventory PlayerInventory;
        PlayerInventory = PlayerInventoryGBJ.GetComponent<PlayerInventory>();
        //PlayerItems myItems = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems;
        if ((PlayerInventory.worker + value < MAX_WorkersvalueSlider))
        {
            workersBar.fillAmount += (float)value / MAX_WorkersvalueSlider;
            int valueInIntegers = Mathf.RoundToInt(workersBar.fillAmount * MAX_WorkersvalueSlider);

            workersText.text = valueInIntegers.ToString();
            PlayerInventory.worker= valueInIntegers;
        }

        else
        {
            workersBar.fillAmount = 1;
            PlayerInventory.worker= MAX_WorkersvalueSlider;
        }
        //money = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Getmoney();


    }
    public void RemoveWorker(int value)
    {
        // UIfunct.workersText, UIfunct.workersBar, UIfunct.PlayerInventoryGBJ
        PlayerInventory PlayerInventory;
        PlayerInventory = PlayerInventoryGBJ.GetComponent<PlayerInventory>();
        //PlayerItems myItems = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems;
        if ((PlayerInventory.worker - value >= 0))
        {
            workersBar.fillAmount -= (float)value / MAX_WorkersvalueSlider;
            int valueInIntegers = Mathf.RoundToInt(workersBar.fillAmount * MAX_WorkersvalueSlider);

            workersText.text = valueInIntegers.ToString();
            PlayerInventory.worker = valueInIntegers;
        }

        else
        {
            
            workersBar.fillAmount = 0;
            PlayerInventory.worker = 0;
        }


    }
    public bool RemoveWorker(int value,GameObject takenplaceObj)
    {
        // UIfunct.workersText, UIfunct.workersBar, UIfunct.PlayerInventoryGBJ
        PlayerInventory PlayerInventory;
        PlayerInventory = PlayerInventoryGBJ.GetComponent<PlayerInventory>();
        //PlayerItems myItems = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems;
        if ((PlayerInventory.worker - value >= 0))
        {
            workersBar.fillAmount -= (float)value / MAX_WorkersvalueSlider;
            int valueInIntegers = Mathf.RoundToInt(workersBar.fillAmount * MAX_WorkersvalueSlider);
            workersText.text = valueInIntegers.ToString() + "/" + Bullet.PlayerMaster.Instance.Totalworkers.ToString();
            PlayerInventory.worker = valueInIntegers;
        }
        else
        {

            NoWorkerUIgeneralcall(value, takenplaceObj);
            return false;

        }
        return true;


    }
    public bool NoWorkerUIgeneralcall(int condition,GameObject actionplace)
    {
        PlayerInventory PlayerInventory;
        PlayerInventory = PlayerInventoryGBJ.GetComponent<PlayerInventory>();
        if (PlayerInventory.worker < condition)
        {
            Instantiate(NoFarmer, actionplace.transform.position + new Vector3(0, 1, 1), actionplace.transform.rotation);
            return true;
        }
        else return false;
    }
    public bool NoWorkerUI(int condition)
    {
        PlayerInventory PlayerInventory;
        PlayerInventory = PlayerInventoryGBJ.GetComponent<PlayerInventory>();
        if (PlayerInventory.worker< condition) {
            Instantiate(NoFarmer, Gamebuilder.transform.GetComponent<Ground_Map>().SelectionBlock[0].transform.position + new Vector3(0, 3, 3), Gamebuilder.transform.GetComponent<Ground_Map>().transform.rotation);
            return true;
        }
        else return false;
    }


    public void activateUpgradeWindow()
    {
        //blackScrean.SetActive(true);
        UpgradeWindow.SetActive(true);
        Shop.SetActive(true);
    }
    public void activateCraftWindow(string name)
    {
        hidechilds(BigPictureParent.transform);
        hidechilds(ItemsCraftParent.transform);
        if (name=="Windmill" || name == "windmill")
        {
            foreach (GameObject child in Windmill)
                child.gameObject.SetActive(true);
        }
        if (name == "cookingPot" || name == "cookingpot" || name == "Cookingpot" || name == "CookingPot")
        {
            foreach (GameObject child in cookingPot)
                child.gameObject.SetActive(true);
        }
        
        //blackScrean.SetActive(true);
        CraftWindow.SetActive(true);
        Shop.SetActive(true);
    }

    public void RemoveMoney(int value)
    {
        //PlayerItems myItems = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems;
        if ((PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Getmoney() - value >= 0))
        {
            moneyBar.fillAmount -= (float)value / MAX_MoneyvalueSlider;
            int moneyInCoins = Mathf.RoundToInt(moneyBar.fillAmount * MAX_MoneyvalueSlider);

            moneyText.text = moneyInCoins.ToString();
            PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Setmoney(moneyInCoins);
            PlayerInventoryGBJ.GetComponent<PlayerInventory>().money = moneyInCoins;

        }

        else
        {
            int amountmissing = -1*PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Getmoney() - value;
            print("You dont Have the money for it ,you need "+ amountmissing + " curency");
            //moneyBar.fillAmount = 0;
            //PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Setmoney(0);
        }
        //money = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Getmoney();


    }
    public IEnumerator SubtractmoneySlow(int n, float waitTime, float recalltime)
    {
        GameObject PlayerInventoryGBJ = this.PlayerInventoryGBJ;
        bool timeToStop = false;
        int moneyInCoins;
        int lerpMoney = n;
        int finalvalue;
        float startbarvalue = moneyBar.fillAmount;
        if (PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Getmoney() - n <= 0)
        {
            PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Setmoney(0);
        }
        else { PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Removemoney(n); }
        finalvalue = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Getmoney();
        while (!timeToStop)
        {

            moneyBar.fillAmount -= (float)lerpMoney / waitTime * Time.deltaTime;
            moneyText.text = moneyBar.fillAmount.ToString();
            moneyInCoins = Mathf.RoundToInt(moneyBar.fillAmount * MAX_MoneyvalueSlider);
            moneyText.text = moneyInCoins.ToString();
            if (moneyInCoins <= finalvalue - (lerpMoney / waitTime))
            {
                moneyBar.fillAmount = startbarvalue - ((float)n / MAX_MoneyvalueSlider);
                //moneyInCoins = Mathf.RoundToInt(moneyBar.fillAmount * MAX_MoneyvalueSlider);
                moneyInCoins = PlayerInventoryGBJ.GetComponent<PlayerInventory>().money;
                moneyText.text = moneyInCoins.ToString();
                timeToStop = true;
            }
            yield return new WaitForSeconds((float)recalltime);
        }
        timeToStop = false;
    }
    public IEnumerator AddmoneySlow(int n, float waitTime,float recalltime)
    {
        GameObject PlayerInventoryGBJ = this.PlayerInventoryGBJ;
        bool timeToStop = false;
        int moneyInCoins;
        int lerpMoney = n;
        int finalvalue;
        float startbarvalue= moneyBar.fillAmount;
        PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Addmoney(n);
        finalvalue = PlayerInventoryGBJ.GetComponent<PlayerInventory>().myItems.Getmoney();
        while (!timeToStop)
        {

            moneyBar.fillAmount += (float)lerpMoney / waitTime * Time.deltaTime;
            moneyText.text = moneyBar.fillAmount.ToString();
            moneyInCoins = Mathf.RoundToInt(moneyBar.fillAmount * MAX_MoneyvalueSlider);
            moneyText.text = moneyInCoins.ToString();
            if (moneyInCoins >= finalvalue - (lerpMoney / waitTime))
            {
                moneyBar.fillAmount = startbarvalue+((float)n / MAX_MoneyvalueSlider);
                moneyInCoins = Mathf.RoundToInt(moneyBar.fillAmount * MAX_MoneyvalueSlider);
                moneyText.text = moneyInCoins.ToString();
                timeToStop = true;
            }
            yield return new WaitForSeconds((float)recalltime);
        }
        timeToStop = false;
    }

    //public IEnumerator writeText(string intext)
    //{
    //    bool a=true;
    //    while (a) {
    //        moneyText.text = intext;
    //        yield return new WaitForSeconds(2f);
        
    //    a = false;
    //    }
    //}



        public void hidechilds(Transform parent)
    {
        foreach (Transform child in parent)
            child.gameObject.SetActive(false);
    }
   public bool NoMoneyUI(int condition)
    {
        PlayerInventory PlayerInventory;
        PlayerInventory = PlayerInventoryGBJ.GetComponent<PlayerInventory>();
        if (PlayerInventory.myItems.Getmoney() < condition)
        {
            Instantiate(NoMoney, Gamebuilder.transform.GetComponent<Ground_Map>().SelectionBlock[0].transform.position + new Vector3(0, 3, 0), Gamebuilder.transform.GetComponent<Ground_Map>().transform.rotation);
            return true;
        }
        else return false;
    }



    public void AddUIElement(int value, int ElementID, bool ElementIsUpgrade, int UpgradeID )
    {

        Debug.Log("Item is "+ UITxt[ElementID].gameObject.activeSelf+"name "+ UITxt[ElementID].gameObject.name);
        if (UITxt[ElementID].transform.parent.gameObject.activeSelf)
        {
            UITxt[ElementID].text = (int.Parse(UITxt[ElementID].text) + value).ToString();
        }
        else
        {
            PlayerInventoryGBJ.GetComponent<PlayerInventory>().ActivateItem(ElementID);
            UITxt[ElementID].text = (int.Parse(UITxt[ElementID].text) + value).ToString();
            
        }
        PlayerInventoryGBJ.GetComponent<PlayerInventory>().Inventory[ElementID].Addamount(value);
        PlayerInventoryGBJ.GetComponent<PlayerInventory>().save();
    }
    public void SetUIElement(int value, int ElementID,bool active)
    {

        Debug.Log("Item is " + UITxt[ElementID].gameObject.activeSelf + "name " + UITxt[ElementID].gameObject.name);
        if (PlayerInventoryGBJ.GetComponent<PlayerInventory>().Inventory[ElementID].isactive())
        {
            UITxt[ElementID].transform.parent.gameObject.SetActive(true);

        }
        UITxt[ElementID].text = (int.Parse(UITxt[ElementID].text+value)).ToString();

    }

    public void RemoveUIElement(int value,int ElementID)
    {
        if (UITxt[ElementID].gameObject.activeSelf)
        {
            UITxt[ElementID].text = (int.Parse(UITxt[ElementID].text) - value).ToString();
        }
        else
        {
            PlayerInventoryGBJ.GetComponent<PlayerInventory>().ActivateItem(ElementID);
            UITxt[ElementID].text = (int.Parse(UITxt[ElementID].text) - value).ToString();
        }
    }
    public void ChangeScene(int sceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
    }


    public void SaveGrounds()
    {
        Bullet.FarmMaster.Instance.MapIDs = Gamebuilder.transform.GetComponent<Ground_Map>().GetMapIDs();
    }






}

