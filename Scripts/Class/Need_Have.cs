using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Need_Have {
    [SerializeField]
    public int IteminMasterID;
    [SerializeField]
    public Text UiTxtConsumedItem;
    [SerializeField]
    public int need;
    [SerializeField]
    public Text needtex;
    private int have;
    [SerializeField]
    public Text havetex;
    [SerializeField]
    public Image haveImage;
    
    [SerializeField]
    public bool canICreate;

    public Need_Have(int newhave,int newneed)
    {
        newhave = have;
        newneed = need;
    }
    public void sethave(int inventory) {
        have = inventory;
    }
    public int gethave()
    {
        return have;
    }

}
