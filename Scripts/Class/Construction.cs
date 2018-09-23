
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How to acces
//Bullet.PlayerMaster.Instance.Construction.functions();

[System.Serializable]
public class Construction
{
    [SerializeField]
    private GameObject BuildableBlocks;
    [Tooltip("")]
    [SerializeField]
    private string BuildableBlocksName;
    [Tooltip("")]
    [SerializeField]
    private GameObject SelectBlocks;
    [Tooltip("")]
    [SerializeField]
    private int BuildableBlocksPrice;
    [Tooltip("")]
    [Header("------------------------------------")]
    [SerializeField]
    private List<GameObject> Upgrades;
    private List<int> UpgradesPrices;
    [Tooltip("")]
    [SerializeField]
    private List<string> UpgradesName;


    public GameObject get_BuildableBlocks()
    {
        return BuildableBlocks;
    }
    public GameObject get_SelectBlocks()
    {
        return SelectBlocks;
    }
    public int getBuildableBlocksPrice()
    {
        return BuildableBlocksPrice;
    }

    //Upgrades
    public GameObject get_UpgradeBlock(int up_ID)
    {
        return Upgrades[up_ID];
    }
    //Names
    public string get_BuildableBlocksName()
    {
        return BuildableBlocksName;
    }
    //Name Upgrades
    public string get_UpgradeName(int n)
    {
        return UpgradesName[n];
    }

    //prices (upgrades)
    public int get_BuildableBlocksPrice()
    {
        return BuildableBlocksPrice;
    }

    public int get_UpgradesPrice(int n)
    {
        return UpgradesPrices[n];
    }
}
